using DenemeMVVM.Commands;
using DenemeMVVM.Models;
using DenemeMVVM.Stores;
using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using Microsoft.Win32;
using NDbUnit.Core;
using DenemeMVVM.Db;

namespace DenemeMVVM.ViewModels
{
    internal class ListOrdersViewModel : ViewModelBase
    {
        public ObservableCollection<Order> _allOrders;

        private DbOperations getOrders = new DbOperations();
        public IEnumerable<Order> AllOrders => _allOrders;


        public ICommand LogOutCommand { get; }
        public ListOrdersViewModel(Restaurant restaurant, NavigationStore navigationStore)
        {
            _allOrders = getOrders.getOrders();
            LogOutCommand = new LogOutCommand(restaurant, navigationStore);
        }

        private Model3DGroup _model;
        public Model3DGroup Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        private Order _selectedItem;
        public Order SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                Model = CreateModel(SelectedItem.MenuItems.Name);
            }
        }


        private Model3DGroup CreateModel(string itemName)
        {
            var modelGroup = new Model3DGroup();

            // Create a MeshBuilder for the plate geometry
            var meshBuilder = new MeshBuilder();

            // Add a cylinder to approximate a plate
            // Parameters: center of the cylinder, axis direction, radius, height, and number of sides
            double radius = 1; // Radius of the plate
            meshBuilder.AddCylinder(new Point3D(0, 0, 0), new Point3D(0, 0.1, 0), radius);

            // Convert the MeshBuilder into a MeshGeometry3D object
            var mesh = meshBuilder.ToMesh();

            // Create a material for the plate            
            var material = new DiffuseMaterial(new SolidColorBrush(Colors.White)); // Plate material can be changed

            // Create a GeometryModel3D with the geometry and material
            var model = new GeometryModel3D(mesh, material);


            var meshBuilderDetail = new MeshBuilder();
            meshBuilderDetail.AddSphere(new Point3D(0, 0.4, 0), 0.3);
            var meshDeatil = meshBuilderDetail.ToMesh();
            var materialDetail = new DiffuseMaterial();
            switch (itemName)
            {
                case "red":
                    materialDetail.Brush = new SolidColorBrush(Colors.Red); break;
                case "blue":
                    materialDetail.Brush = new SolidColorBrush(Colors.Blue); break;
                case "yellow":
                    materialDetail.Brush = new SolidColorBrush(Colors.Yellow); break;
                case "green":
                    materialDetail.Brush = new SolidColorBrush(Colors.Green); break;

            }
            var modelDetail = new GeometryModel3D(meshDeatil, materialDetail);

            // Add the plate model to the Model3DGroup
            modelGroup.Children.Add(model);
            modelGroup.Children.Add(modelDetail);

            return modelGroup;
        }

    }
}

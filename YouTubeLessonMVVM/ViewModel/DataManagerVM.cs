using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using YouTubeLessonMVVM.Model;
using YouTubeLessonMVVM.View.Add;
using YouTubeLessonMVVM.View.Edit;

namespace YouTubeLessonMVVM.ViewModel
{
    public class DataManagerVM : INotifyPropertyChanged
    {
        // все отделы
        private List<Department> allDepartments = DataWorker.GetAllDepartments();
        public List<Department> AllDepartments 
        { 
            get { return allDepartments; }
            set 
            {
                allDepartments = value;
                NotifyPropertyChanged("AllDepartments");
            }
        }

        // все позиции
        private List<Position> allPositions = DataWorker.GetAllPositions();
        public List<Position> AllPositions
        {
            get { return allPositions; }
            set
            {
                allPositions = value;
                NotifyPropertyChanged("AllPositions");
            }
        }

        // все сотрудники
        private List<Staff> allStaffs = DataWorker.GetAllStaffs();
        public List<Staff> AllStaffs
        {
            get { return allStaffs; }
            set
            {
                allStaffs = value;
                NotifyPropertyChanged("AllStaffs");
            }
        }

        #region COMMANDS TO OPEN WINDOWS

        private RelayCommand openAddNewDepartmentWnd;
        public RelayCommand OpenAddNewDepartmentWnd
        {
            get 
            {
                return openAddNewDepartmentWnd ?? new RelayCommand(obj =>
                {
                    OpenAddDepartmentWindowMethod();
                });
             }
        }

        private RelayCommand openAddNewPositionWnd;
        public RelayCommand OpenAddNewPositionWnd
        {
            get
            {
                return openAddNewPositionWnd ?? new RelayCommand(obj =>
                {
                    OpenAddPositionWindowMethod();
                });
            }
        }

        private RelayCommand openAddNewStaffWnd;
        public RelayCommand OpenAddNewStaffWnd
        {
            get
            {
                return openAddNewStaffWnd ?? new RelayCommand(obj =>
                {
                    OpenAddStaffWindowMethod();
                });
            }
        }

        #endregion

        #region METHODS TO OPEN WINDOW
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        // методы открытия окон
        private void OpenAddDepartmentWindowMethod()
        {
            AddNewDepartmentWindow newDepartmentWindow = new AddNewDepartmentWindow();
            SetCenterPositionAndOpen(newDepartmentWindow);
        }
        private void OpenAddPositionWindowMethod()
        {
            AddNewPositionWindow newPositionWindow = new AddNewPositionWindow();
            SetCenterPositionAndOpen(newPositionWindow);
        }
        private void OpenAddStaffWindowMethod()
        {
            AddNewStaffWindow newStaffWindow = new AddNewStaffWindow();
            SetCenterPositionAndOpen(newStaffWindow);
        }

        // методы редактирования 
        private void OpenEditDepartmentWindowMethod()
        {
            EditDepartmentWindow editDepartmentWindow = new EditDepartmentWindow();
            SetCenterPositionAndOpen(editDepartmentWindow);
        }
        private void OpenEditPositionWindowMethod()
        {
            EditPosition editPositionWindow = new EditPosition();
            SetCenterPositionAndOpen(editPositionWindow);
        }
        private void OpenEdittaffWindowMethod()
        {
            EditStaffWindow editStaffWindow = new EditStaffWindow();
            SetCenterPositionAndOpen(editStaffWindow);
        }
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

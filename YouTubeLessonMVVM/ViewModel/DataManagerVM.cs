using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using YouTubeLessonMVVM.Model;
using YouTubeLessonMVVM.View;
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


        // свойства для отедла
        public string? DepartmentName { get; set; }

        // свойства для позиций
        public string? PositionName { get; set; }
        public decimal PositionSalary { get; set; }
        public int PositionMaxNumber { get; set; }
        public Department? PositionDepartment { get; set; }

        // свойства для сотрудников
        public string? StaffName { get; set; }
        public string? StaffSurname { get; set; }
        public string? StaffPhone { get; set; }
        public Position? StaffPosition { get; set; }


        #region COMMANDS TO ADD

        private RelayCommand addNewDepartment;
        public RelayCommand AddNewDepartment
        {
            get
            {
                return addNewDepartment ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    if (DepartmentName == null || DepartmentName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "NameBlock");
                    }
                    else
                    {
                        string resultStr = DataWorker.CreateDepartment(DepartmentName);
                        UpdateAllDataView();
                        ShowMessageToUSer(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }

                });
            }
        }


        private RelayCommand addNewPosition;
        public RelayCommand AddNewPosition
        {
            get
            {
                return addNewPosition ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool CanAdd = true;
                    if (PositionName == null || PositionName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "NameBlock"); CanAdd = false;
                    }
                    if (PositionSalary == 0)
                    {
                        SetRedBlockControl(wnd, "SalaryBlock"); CanAdd = false;
                    }
                    if (PositionMaxNumber == 0)
                    {
                        SetRedBlockControl(wnd, "MaxNumberBlock"); CanAdd = false;
                    }
                    if (PositionDepartment == null)
                    {
                        MessageBox.Show("Укажите отдел"); CanAdd = false;
                    }
                    if (CanAdd)                   
                    {
                        string resultStr = DataWorker.CreatePosition(PositionName, PositionSalary, PositionMaxNumber, PositionDepartment);
                        UpdateAllDataView();

                        ShowMessageToUSer(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }


        private RelayCommand addNewStaff;
        public RelayCommand AddNewStaff
        {
            get
            {
                return addNewStaff ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool CanAdd = true;
                    if (StaffName == null || StaffName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "NameBlock"); CanAdd = false;
                    }
                    if (StaffSurname == null || StaffSurname.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "SurNameBlock"); CanAdd = false;
                    }
                    if (StaffPhone == null || StaffPhone.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "PhoneBlock"); CanAdd = false;
                    }
                    if (StaffPosition == null)
                    {
                        MessageBox.Show("Укажите позицию"); CanAdd = false;
                    }
                    if (CanAdd)
                    {
                        string resultStr = DataWorker.CreateStaff(StaffName, StaffSurname, StaffPhone, StaffPosition);
                        UpdateAllDataView();

                        ShowMessageToUSer(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }



        private void SetRedBlockControl(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        #endregion

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

        #region UPDATE VIEWS
        private void SetNullValuesToProperties()
        {
            // для сотрудников
            StaffName = null;
            StaffSurname = null;
            StaffPhone = null;
            StaffPosition = null;

            // для позиций
            PositionName = null; 
            PositionSalary = 0; 
            PositionMaxNumber = 0;
            PositionDepartment = null;

            // для отделов
            DepartmentName = null;
        }


        private void UpdateAllDataView()
        {
            UpdateAllDepartmentsViews();
            UpdateAllPositions();
            UpdateAllStaffs();
        }

        private void UpdateAll(IList lst, ListView view)
        {
            view.ItemsSource = null;
            view.Items.Clear();
            view.ItemsSource = lst;
            view.Items.Refresh();
        }

        private void UpdateAllDepartmentsViews()
        {
            AllDepartments = DataWorker.GetAllDepartments();
            UpdateAll(AllDepartments, MainWindow.AllDepartmentsView);
        }

        private void UpdateAllPositions()
        {
            AllPositions = DataWorker.GetAllPositions();
            UpdateAll(AllPositions, MainWindow.AllPositionsView);
        }

        private void UpdateAllStaffs()
        {
            AllStaffs = DataWorker.GetAllStaffs();
            UpdateAll(AllStaffs, MainWindow.AllStaffsView);
        }

        #endregion

        private void ShowMessageToUSer(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

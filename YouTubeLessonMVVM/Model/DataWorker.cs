using YouTubeLessonMVVM.Model.Data;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Documents;
using System.Collections.Generic;

namespace YouTubeLessonMVVM.Model
{
    public static class DataWorker
    {
        // получить все отделы
        public static List<Department> GetAllDepartments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Departments.ToList();
                return result;
            }
        }

        // получить все позиции
        public static List<Position> GetAllPositions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Positions.ToList();
                return result;
            }
        }

        // получить всех сотрудников
        public static List<Staff> GetAllStaffs()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Staffs.ToList();
                return result;
            }
        }


        // создать отдел
        public static string CreateDepartment(string name)
        {
            string result = "Уже существует";
            using(ApplicationContext db = new ApplicationContext())
            {
                // проверяем существует ли отдел
                bool checkIsExist = db.Departments.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    Department newDepartment = new Department { Name = name };
                    db.Departments.Add(newDepartment);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }

        // создать позицию
        public static string CreatePosition(string name, decimal salary, int maxNumber, Department department)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                // проверяем существует ли позиция
                bool checkIsExist = db.Positions.Any(el => el.Name == name && el.Salary == salary);
                if (!checkIsExist)
                {
                    Position newPositions = new Position 
                    { 
                        Name = name,
                        Salary = salary,
                        MaxNumber = maxNumber,
                        DepartmentId = department.Id
                    };
                    db.Positions.Add(newPositions);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }

        // создать сотрудника
        public static string CreateStaff(string name, string surName, string phone, Position position)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                // проверяем существует ли позиция
                bool checkIsExist = db.Staffs.Any(el => el.Name == name && el.Surname == surName && el.Phone == phone && el.Position == position);
                if (!checkIsExist)
                {
                    Staff newStaff = new Staff
                    {
                        Name = name,
                        Surname = surName,
                        Phone = phone,
                        PositionId = position.Id
                    };
                    db.Staffs.Add(newStaff);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }


        // удалить отдел
        public static string DeleteDepartment(Department department)
        {
            string result = "Такого отдела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Departments.Remove(department);
                db.SaveChanges();
                result = "Выполнено! Отдел " + department.Name + " удален";
            }
            return result;
        }

        // удалить позицию
        public static string DeletePosition(Position position)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Positions.Remove(position);
                db.SaveChanges();
                result = "Выполнено! Позиция " + position.Name + " удалена";
            }
            return result;
        }

        // удалить сотрудника
        public static string DeleteStaff(Staff staff)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Staffs.Remove(staff);
                db.SaveChanges();
                result = "Выполнено! Сотрудник " + staff.Name + " уволен";
            }
            return result;
        }


        // редактировать отдел
        public static string EditDepartment(Department oldDepartment, string newName)
        {
            string result = "Такого отдела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Department? department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                if (department != null)
                {
                    department.Name = newName;
                    db.SaveChanges();
                    result = "Выполнено! Отдел " + department.Name + " изменен";
                }

            }
            return result;
        }

        // редактировать позицию
        public static string EditPosition(Position oldPosition, string newName, int newMaxNumber, decimal newSalary, Department newDepartment)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Position? position = db.Positions.FirstOrDefault(p => p.Id == oldPosition.Id);
                if (position != null)
                {
                    position.Name = newName;
                    position.Salary = newSalary;
                    position.MaxNumber = newMaxNumber;
                    position.DepartmentId = newDepartment.Id;
                    db.SaveChanges();
                    result = "Выполнено! Позиция " + position.Name + " изменена";
                }
            }
            return result;
        }

        // редактировать сотрудника
        public static string EditStaf(Staff oldStaff, string newName, string newSurname, string newPhone, Position newPosition)
        {
            string result = "Такого отдела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Staff? staff = db.Staffs.FirstOrDefault(s => s.Id == oldStaff.Id);
                if (staff != null)
                {
                    string oldName = staff.Name;

                    staff.Name = newName;
                    staff.Surname = newSurname;
                    staff.Phone = newPhone;
                    staff.PositionId = newPosition.Id;
                    db.SaveChanges();
                    result = "Выполнено! Данное о сотруднике " + oldName + " изменен";
                }
            }
            return result;
        }
    }
}

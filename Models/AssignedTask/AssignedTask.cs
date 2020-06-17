using System;
using System.Collections.Generic;
using apc_bot_api.Models.Sendler;
using apc_bot_api.Models.Users;

namespace apc_bot_api.Models.AssignedTasks
{
    public class AssignedTaskForm
    {
        public string Text { get; set; }
        // public DateTime FinishDate { get; set; }
        public int Year { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
    }

    public class AssignedTask
    {
        public AssignedTask() { }

        public AssignedTask(int _id, string _text, Teacher _setBy, DateTime _startDate, DateTime _finishDate)
        {
            Id = _id;
            Text = _text;
            SetBy = _setBy;
            StartDate = _startDate;
            FinishDate = _finishDate;
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public Teacher SetBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class AssignedTaskViewModel
    {
        public int Id { get; set; }
        public string TeacherFullName { get; set; }
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }

    public class SendlerTaskViewModel
    {
        public SendlerTaskViewModel(List<StudentReceiverViewModel> studentList, AssignedTaskViewModel assignedTask)
        {
            StudentList = studentList;
            AssignedTask = assignedTask;
        }

        public List<StudentReceiverViewModel> StudentList { get; set; }
        public AssignedTaskViewModel AssignedTask { get; set; }
    }
}
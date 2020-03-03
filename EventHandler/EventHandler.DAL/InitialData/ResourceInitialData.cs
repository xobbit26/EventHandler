using EventHandler.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventHandler.DAL.InitialData
{
    class ResourceInitialData
    {
        public static void Init(ModelBuilder modelBuilder)
        {
            InitEnglishResources(modelBuilder);
            InitRussianResources(modelBuilder);
        }

        private static void InitEnglishResources(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppName_Label", Locale = "EN", Text = "Event Handler" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppBar_Login_Label", Locale = "EN", Text = "Login" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppBar_Create_Event_Label", Locale = "EN", Text = "Create Event" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppBar_Event_List_Label", Locale = "EN", Text = "Event List" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppBar_Reports_Label", Locale = "EN", Text = "Reports" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppBar_Reports_Administration", Locale = "EN", Text = "Administration" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppBar_Reports_Settings", Locale = "EN", Text = "Settings" });

            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "EventsTable_Header_FullName", Locale = "EN", Text = "FullName" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "EventsTable_Header_ApplyDateTime", Locale = "EN", Text = "Date Time" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "EventsTable_Header_Description", Locale = "EN", Text = "Description" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "EventsTable_Header_Responsible", Locale = "EN", Text = "Responsible" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "EventsTable_Header_Status", Locale = "EN", Text = "Status" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "EventsTable_Header_ResolveDateTime", Locale = "EN", Text = "Resolving Date Time" });

            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "CreateEvent_FullName_Label", Locale = "EN", Text = "Full Name" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "CreateEvent_Department_Label", Locale = "EN", Text = "Department" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "CreateEvent_Description_Label", Locale = "EN", Text = "Description" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "CreateEvent_Submit_Button_Label", Locale = "EN", Text = "Submit" });

            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "LoginPage_Login_Label", Locale = "EN", Text = "Login" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "LoginPage_Password_Label", Locale = "EN", Text = "Password" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "LoginPage_Enter_Label", Locale = "EN", Text = "Enter" });

            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "SuccessMessage_EventCreated", Locale = "EN", Text = "Event Successfully Created!" });
        }

        private static void InitRussianResources(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppName_Label", Locale = "RU", Text = "Event Handler" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppBar_Login_Label", Locale = "RU", Text = "Логин" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppBar_Create_Event_Label", Locale = "RU", Text = "Создать заявку" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppBar_Event_List_Label", Locale = "RU", Text = "Список заявок" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppBar_Reports_Label", Locale = "RU", Text = "Отчеты" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppBar_Reports_Administration", Locale = "RU", Text = "Управление" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppBar_Reports_Settings", Locale = "RU", Text = "Настройки" });

            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "EventsTable_Header_FullName", Locale = "RU", Text = "ФИО подавшего заявку" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "EventsTable_Header_ApplyDateTime", Locale = "RU", Text = "Дата и время подачи" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "EventsTable_Header_Description", Locale = "RU", Text = "Описание" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "EventsTable_Header_Responsible", Locale = "RU", Text = "Ответственный" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "EventsTable_Header_Status", Locale = "RU", Text = "Статус" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "EventsTable_Header_ResolveDateTime", Locale = "RU", Text = "Дата и время выполнения" });

            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "CreateEvent_FullName_Label", Locale = "RU", Text = "ФИО" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "CreateEvent_Department_Label", Locale = "RU", Text = "Отдел" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "CreateEvent_Description_Label", Locale = "RU", Text = "Описание" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "CreateEvent_Submit_Button_Label", Locale = "RU", Text = "Отправить" });

            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "LoginPage_Login_Label", Locale = "RU", Text = "Логин" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "LoginPage_Password_Label", Locale = "RU", Text = "Пароль" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "LoginPage_Enter_Label", Locale = "RU", Text = "Войти" });

            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "SuccessMessage_EventCreated", Locale = "RU", Text = "Заявка успешно создана!" });
        }
    }
}

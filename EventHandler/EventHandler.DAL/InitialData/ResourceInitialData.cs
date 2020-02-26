using EventHandler.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventHandler.DAL.InitialData
{
    class ResourceInitialData
    {
        public static void Init(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "AppName_Label", Locale = "EN", Text = "EventHandler" });
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

            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "CreateEvent_FullName_Label", Locale = "EN", Text = "FullName" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "CreateEvent_Department_Label", Locale = "EN", Text = "Department" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "CreateEvent_Description_Label", Locale = "EN", Text = "Description" });
            modelBuilder.Entity<Resource>().HasData(new Resource() { Id = "CreateEvent_Submit_Button_Label", Locale = "EN", Text = "Submit" });
        }
    }
}

using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using WpfScheduler.ViewModel;

namespace WpfScheduler
{
    public class MonthCellTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonthCellTemplateSelector" /> class.
        /// </summary>
        public MonthCellTemplateSelector()
        {
            var mainWindow = App.Current.MainWindow as Window;
            this.MonthAppointmentTemplate = mainWindow.Resources["monthAppointmentTemplate"] as DataTemplate;
            this.MonthCellDatesTemplate = mainWindow.Resources["monthCellTemplate"] as DataTemplate;
        }

        /// <summary>
        /// Gets or sets Month Appointment Template.
        /// </summary>
        public DataTemplate MonthAppointmentTemplate { get; set; }

        /// <summary>
        /// Gets or sets Month Cell Dates Template.
        /// </summary>
        public DataTemplate MonthCellDatesTemplate { get; set; }

        /// <summary>
        /// Template selection method
        /// </summary>
        /// <param name="item">return the object</param>
        /// <param name="container">return the bindable object</param>
        /// <returns>return the template</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            var appointments = item as List<ScheduleAppointment>;
            var cell = container as MonthCell;

            if (cell.DateTime.Date == DateTime.Now.Date)
                cell.Foreground = Brushes.Black;
            if (appointments == null || appointments.Count == 0)
            {
                cell.DataContext = cell;
                return MonthCellDatesTemplate;
            }
            else
            {
                MonthCellViewModel monthCellViewModel = new MonthCellViewModel();
                monthCellViewModel.Foreground = cell.Foreground;
                monthCellViewModel.DateText = cell.DateText;
                monthCellViewModel.AppointmentCount = appointments.Count.ToString();
                cell.DataContext = monthCellViewModel;
                return MonthAppointmentTemplate;
            }
        }
    }
}
       
    




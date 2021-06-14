using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfScheduler.ViewModel
{
    public class MonthCellViewModel : INotifyPropertyChanged
    {
        #region Properties
        /// <summary>
        /// Property changed event handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Gets or sets month foreground.
        /// </summary>
        public Brush Foreground { get; set; }
        /// <summary>
        /// Gets or sets month date.
        /// </summary>
        public string DateText { get; set; }
        /// <summary>
        /// Gets or sets month cell appointments.
        /// </summary>
        public string AppointmentCount { get; set; }
        #endregion
        #region Property Changed Event
        /// <summary>
        /// Invoke method when property changed
        /// </summary>
        /// <param name="propertyName">property name</param>
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

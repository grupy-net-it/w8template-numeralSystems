using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using NumeralSystems.Annotations;

namespace NumeralSystems
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int intValue = -1;
        private string binary;
        private string octal;
        private string @decimal;
        private string hexadecimal;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Binary
        {
            get
            {
                return binary;
            }

            set
            {
                intValue = string.IsNullOrWhiteSpace(value) ? -1 : Convert.ToInt32(value, 2);
                RefreshValues();
            }
        }

        public string Octal
        {
            get
            {
                return octal;
            }

            set
            {
                intValue = string.IsNullOrWhiteSpace(value) ? -1 : Convert.ToInt32(value, 8);
                RefreshValues();
            }
        }

        public string Decimal
        {
            get
            {
                return @decimal;
            }

            set
            {
                intValue = string.IsNullOrWhiteSpace(value) ? -1 : Convert.ToInt32(value, 10);
                RefreshValues();
            }
        }

        public string Hexadecimal
        {
            get
            {
                return hexadecimal;
            }

            set
            {
                intValue = string.IsNullOrWhiteSpace(value) ? -1 : Convert.ToInt32(value, 16);
                RefreshValues();
            }
        }

        public void Reset()
        {
            intValue = -1;
            RefreshValues();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void RefreshValues()
        {
            if (intValue < 0)
            {
                binary = string.Empty;
                octal = string.Empty;
                @decimal = string.Empty;
                hexadecimal = string.Empty;
            }
            else
            {
                binary = Convert.ToString(intValue, 2);
                octal = Convert.ToString(intValue, 8);
                @decimal = Convert.ToString(intValue, 10);
                hexadecimal = Convert.ToString(intValue, 16);
            }
            
            ReleasePropertiesChanges();
        }

        private void ReleasePropertiesChanges()
        {
            OnPropertyChanged("Binary");
            OnPropertyChanged("Decimal");
            OnPropertyChanged("Octal");
            OnPropertyChanged("Hexadecimal");
        }
    }
}

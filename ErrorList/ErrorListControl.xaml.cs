/* ErrorList
 * http://Suplanus.de by Johann Weiher
 * 
 * Control based on the Idea: http://errorlist.codeplex.com/
 * 
 */
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;

namespace ErrorList
{
    public partial class ErrorListControl : IErrorList
    {
        private readonly ErrorListDataModel _dataContext = new ErrorListDataModel();

        public ErrorListControl()
        {
            InitializeComponent();

            dgv.DataContext = _dataContext;
            SetTextBoxBindings();
        }

        #region IErrorListReporter

        public ObservableCollection<ErrorListDataEntry> DataBindingContext
        {
            get { return _dataContext.ErrorListData; }
            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("Unable to bind to a null reference");
                }

                _dataContext.ErrorListData = value;
            }
        }

        public bool ErrorsVisible
        {
            get
            {
                return tglBtnErrors.IsChecked.HasValue && tglBtnErrors.IsChecked.Value;
            }
            set
            {
                tglBtnErrors.IsChecked = value;
            }
        }

        public bool WarningsVisible
        {
            get
            {
                return tglBtnWarnings.IsChecked.HasValue && tglBtnWarnings.IsChecked.Value;
            }
            set
            {
                tglBtnWarnings.IsChecked = value;
            }
        }

        public bool MessagesVisible
        {
            get
            {
                return tglBtnMessages.IsChecked.HasValue && tglBtnMessages.IsChecked.Value;
            }
            set
            {
                tglBtnMessages.IsChecked = value;
            }
        }

        public void ClearAll()
        {
            _dataContext.ErrorListData = new ObservableCollection<ErrorListDataEntry>();
        }

        public void AddError(string description)
        {
            _dataContext.AddError(description);
        }

        public void AddWarning(string description)
        {
            _dataContext.AddWarning(description);
        }

        public void AddInformation(string description)
        {
            _dataContext.AddInformation(description);
        }

        #endregion IErrorListReporter

        #region EventHandlers

        private void Errors_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            ToggleButton tgl = (ToggleButton)sender;
            _dataContext.ShowErrors = tgl.IsChecked.HasValue && tgl.IsChecked.Value;
        }

        private void Errors_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            ToggleButton tgl = (ToggleButton)sender;
            _dataContext.ShowErrors = tgl.IsChecked.HasValue && tgl.IsChecked.Value;
        }

        private void Warnings_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            ToggleButton tgl = (ToggleButton)sender;
            _dataContext.ShowWarnings = tgl.IsChecked.HasValue && tgl.IsChecked.Value;
        }

        private void Warnings_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            ToggleButton tgl = (ToggleButton)sender;
            _dataContext.ShowWarnings = tgl.IsChecked.HasValue && tgl.IsChecked.Value;
        }

        private void Informations_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            ToggleButton tgl = (ToggleButton)sender;
            _dataContext.ShowInformations = tgl.IsChecked.HasValue && tgl.IsChecked.Value;
        }

        private void Informations_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            ToggleButton tgl = (ToggleButton)sender;
            _dataContext.ShowInformations = tgl.IsChecked.HasValue && tgl.IsChecked.Value;
        }

        #endregion EventHandlers

        private void SetTextBoxBindings()
        {
            txtErrors.DataContext = _dataContext;
            txtWarnings.DataContext = _dataContext;
            txtMessages.DataContext = _dataContext;
        }




    }
}

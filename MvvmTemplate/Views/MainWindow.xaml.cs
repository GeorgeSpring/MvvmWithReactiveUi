using System.Reactive.Disposables;
using System.Windows.Forms;
using MvvmTemplate.ViewModels;
using ReactiveUI;

namespace MvvmTemplate.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml Обязательно нужно реализовать ReactiveWindow с указанием вьюмодели
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            //Задаем вью модель
            ViewModel = new MainWindowViewModel();

            //Это дело вызовется когда у нас появится вью модель, тут происходят почти все биндинги (кроме списков)
            this.WhenActivated(disposable =>
            {
                //Bind == привязка, первый параметр вью модель куда мы привязываемся, второй параметр - что мы привязываем, третий параметр - к чему привязываем
                //конкретно тут привязываем переменную счетчика к тексту на кнопке
                this.Bind(ViewModel, x => x.Data, x => x.ClickButton.Content).DisposeWith(disposable);

                //Привязываем список клиентов к DataContext-у листвью
                this.Bind(ViewModel, x => x.ClientsList, x => x.ClientsListView.DataContext).DisposeWith(disposable);

                //Привязка команд к кнопкам (то что будет происходить при нажатии на кнопку)
                this.BindCommand(ViewModel, x => x.ClickCommand, x => x.ClickButton).DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.AddCommand, x => x.AddButton).DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.RemoveCommand, x => x.RemoveButton).DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.EditCommand, x => x.EditButton).DisposeWith(disposable);

                //Привязка выбранного элемента к переменной из вью модели, когда мы на интерфейсе будем менять выбранный элемент, эта переменная будет содержать
                //выбранное значение
                this.Bind(ViewModel, x => x.SelectedClient, x => x.ClientsListView.SelectedItem).DisposeWith(disposable);
            });
        }
    }
}

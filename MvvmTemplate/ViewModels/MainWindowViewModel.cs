using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using DynamicData;
using MvvmTemplate.Classes;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace MvvmTemplate.ViewModels
{
    //Вью модель для MainWindowVieModel, сюда должны идти все привязки с вьюхи
    public class MainWindowViewModel : ReactiveObject
    {
        //команды нажания на кнопки то что указано в <>, на 1 месте это возвращаемое значение (если его нет пишем Unit), а на втором то, что передаем 
        //в команду (если нет, то тоже Unit)

        /// <summary>
        /// Команда для кнопки кликера
        /// </summary>
        public ReactiveCommand<Unit, Unit> ClickCommand { get; }

        /// <summary>
        /// Команда добавления человека в список
        /// </summary>
        public ReactiveCommand<Unit, Unit> AddCommand { get; }

        /// <summary>
        /// Команда удаления человека из списка
        /// </summary>
        public ReactiveCommand<Unit, Unit> RemoveCommand { get; }

        /// <summary>
        /// Команда редактирования человека
        /// </summary>
        public ReactiveCommand<Unit, Unit> EditCommand { get; }

        //Атрибут [Reactive] позволяет уведомлять интерфейс о том, что объект изменился. 
        //т.е. если у нас есть привязка во вьюхе к этому объекту, когда мы поменяем его в коде тут
        //он автоматически обновится и на вьюхе

        /// <summary>
        /// Список всех клиентов, ObservableCollection - это как List, только он умеет оповещать интерфейс о том,
        /// что его содержимое изменилось (что-то добавилось или удалилось)
        /// </summary>
        [Reactive] 
        public ObservableCollection<Client> ClientsList { get; set; } = new ObservableCollection<Client>();

        /// <summary>
        /// Выбранный клиент, берется из списка
        /// </summary>
        [Reactive]
        public Client SelectedClient { get; set; }

        /// <summary>
        /// Свойства для счетчика кликера
        /// </summary>
        [Reactive]
        public int Data { get; set; }

        public MainWindowViewModel()
        {
            ClientsList.Add(new Client { Id = 1, LastName = "Иванов", Name = "Иван", Patronymic = "Иванович" });
            
            //Инициализация команда (задаем поведение при вызове команды)

            //Можно задать с помощью анонимной функции
            ClickCommand = ReactiveCommand.Create(() => { Data++; });

            //А можно задать из метода
            AddCommand = ReactiveCommand.Create(AddImp);
            EditCommand = ReactiveCommand.Create(EditImp);
            RemoveCommand = ReactiveCommand.Create(RemoveImp);
        }

        /// <summary>
        /// Реализация метода добавления сотрудника (тут мы работаем только со списоком, об вьюхе и списке на ней мы ничего не знаем)
        /// </summary>
        private void AddImp()
        {
            ClientsList.Add(new Client { Id = 1, LastName = "Иванов", Name = "Иван", Patronymic = "Иванович" });
        }

        /// <summary>
        /// Редактирование выбранного клиента
        /// </summary>
        private void EditImp()
        {
            if (SelectedClient != null)
                SelectedClient.Id = new Random().Next(0, 100);
        }

        /// <summary>
        /// Удаление выбранного клиента
        /// </summary>
        private void RemoveImp()
        {
            if(SelectedClient!= null)
                ClientsList.Remove(SelectedClient);
        }
    }
}
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace MvvmTemplate.Classes
{
    //Атрибут [Reactive] позволяет уведомлять интерфейс о том, что объект изменился. 
    //т.е. если у нас есть привязка во вьюхе к этому объекту, когда мы поменяем его в коде тут
    //он автоматически обновится и на вьюхе
    //чтобы все работало, нужно унаследовать ReactiveObject
    //Все это идет из библиотеки ReactiveUi.Wpf и ReactiveUi.Fody
    public class Client : ReactiveObject
    {
        [Reactive]
        public string Name { get; set; }
        [Reactive]
        public int Id { get; set; }
        [Reactive]
        public string LastName { get; set; }
        [Reactive]
        public string Patronymic { get; set; }
    }
}
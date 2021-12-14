using SemaphoreTask.Command;
using SemaphoreTask.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SemaphoreTask.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        Stopwatch stopwatch1;
        Stopwatch stopwatch2;
        DispatcherTimer dispatcher = new DispatcherTimer();
        public MainWindow MainView { get; set; }

        public RelayCommand StartCommand { get; set; }

        //bmw
        private ObservableCollection<Car> _bmw;
        public ObservableCollection<Car> Bmw
        {
            get { return _bmw; }
            set { _bmw = value; OnPropertyChanged(); }
        }

        //mercedes
        private ObservableCollection<Car> _mercedes;
        public ObservableCollection<Car> Mercedes
        {
            get { return _mercedes; }
            set { _mercedes = value; OnPropertyChanged(); }
        }

        //chevrolet
        private ObservableCollection<Car> _chevrolet;
        public ObservableCollection<Car> Chevrolet
        {
            get { return _chevrolet; }
            set { _chevrolet = value; OnPropertyChanged(); }
        }

        //hyundai
        private ObservableCollection<Car> _hyundai;
        public ObservableCollection<Car> Hyundai
        {
            get { return _hyundai; }
            set { _hyundai = value; OnPropertyChanged(); }
        }

        //toyota
        private ObservableCollection<Car> _toyota;
        public ObservableCollection<Car> Toyota
        {
            get { return _toyota; }
            set { _toyota = value; OnPropertyChanged(); }
        }




        private ObservableCollection<Car> _newCars;

        public ObservableCollection<Car> NewCars
        {
            get { return _newCars; }
            set { _newCars = value; OnPropertyChanged(); }
        }

        public int Count { get; set; } = 0;




        public RelayCommand AddCarsCommand { get; set; }

        public MainViewModel()
        {

            dispatcher.Interval = TimeSpan.FromSeconds(2);
            dispatcher.Tick += Dispatcher_Tick;

            AddCarsCommand = new RelayCommand((sender) =>
            {
                //Bmw
                Bmw = new ObservableCollection<Car>
            {
                new Car()
                {
                    Id=1,
                    Model="M5",
                    Vendor="Bmw",
                    Year=2018,
                    ImagePath="../Images/Bmw_M5_2018.jpg"

                },
                new Car()
                {
                    Id=2,
                    Model="X6",
                    Vendor="Bmw",
                    Year=2010,
                    ImagePath="../Images/Bmw_X6_2018.jpg"

                },
                new Car()
                {
                    Id=3,
                    Model="528",
                    Vendor="Bmw",
                    Year=2018,
                    ImagePath="../Images/Bmw_528_2018.jpg"
                }
            };
                FileHelper.JsonHelper.JSONSerialization(Bmw, "Bmw.json");

                //Mercedes
                Mercedes = new ObservableCollection<Car>
            {
                new Car()
                {
                    Id=1,
                    Model="S500",
                    Vendor="Mersedes",
                    Year=2020,
                    ImagePath="../Images/Mercedes_S500_2020.jpg "

                },
                new Car()
                {
                    Id=2,
                    Model="GLS",
                    Vendor="Mersedes",
                    Year=2020,
                    ImagePath="../Images/Mercedes_Gls_2020.jpg"

                },
                new Car()
                {
                    Id=3,
                    Model="C240",
                    Vendor="Mersedes",
                    Year=2001,
                    ImagePath="../Images/Mercedes_C240_2001.jpg"
                }
            };
                FileHelper.JsonHelper.JSONSerialization(Mercedes, "Mercedes.json");

                //Chevrolet
                Chevrolet = new ObservableCollection<Car>
            {
                new Car()
                {
                    Id=1,
                    Model="Captiva",
                    Vendor="Chevrolet",
                    Year=2021,
                    ImagePath="../Images/Chevrolet_Captiva_2021.jpg"

                },
                new Car()
                {
                    Id=2,
                    Model="Cruze",
                    Vendor="Chevrolet",
                    Year=2014,
                    ImagePath="../Images/Chevrolet_Cruze_2014.jpg"

                },
                new Car()
                {
                    Id=3,
                    Model="Malibu",
                    Vendor="Chevrolet",
                    Year=2017,
                    ImagePath="../Images/Chevrolet_Malibu_2017.jpg"
                }
            };
                FileHelper.JsonHelper.JSONSerialization(Chevrolet, "Chevrolet.json");


                //Hyundai
                Hyundai = new ObservableCollection<Car>
            {
                new Car()
                {
                    Id=1,
                    Model="Elentra",
                    Vendor="Hyundai",
                    Year=2017,
                    ImagePath="../Images/Hyundai_Elentra_2017.jpg "

                },
                new Car()
                {
                    Id=2,
                    Model="Santa Fe",
                    Vendor="Hyundai",
                    Year=2021,
                    ImagePath="../Images/Hyundai_Santafe_2021.jpg"

                },
                new Car()
                {
                    Id=3,
                    Model="Accent",
                    Vendor="Hyundai",
                    Year=2018,
                    ImagePath="../Images/Hyundai_Accent_2018.jpg "
                }
            };
                FileHelper.JsonHelper.JSONSerialization(Hyundai, "Hyundai.json");
                //Toyota
                Toyota = new ObservableCollection<Car>
            {
                new Car()
                {
                    Id=1,
                    Model="Prado",
                    Vendor="Toyota",
                    Year=2012,
                    ImagePath="../Images/Toyota_Prado_2012.jpg "

                },
                new Car()
                {
                    Id=2,
                    Model="Prius",
                    Vendor="Toyota",
                    Year=2011,
                    ImagePath="../Images/Toyota_Prius_2011.jpg "

                },
                new Car()
                {
                    Id=3,
                    Model="Corolla",
                    Vendor="Toyota",
                    Year=2006,
                    ImagePath="../Images/Toyota_Corolla_2006.jpg "
                }
            };
                FileHelper.JsonHelper.JSONSerialization(Toyota, "Toyota.json");

                MessageBox.Show("All Cars are added");

            });

            StartCommand = new RelayCommand((sender) =>
            {
                NewCars = new ObservableCollection<Car>();

                MainViewModel mainViewModel = new MainViewModel();

                if (MainView.MyToogleButton.IsChecked == false)
                {
                    stopwatch1 = new Stopwatch();
                    stopwatch1.Start();
                    dispatcher.Start();

                }

                if (MainView.MyToogleButton.IsChecked == true)
                {

                    stopwatch2 = new Stopwatch();
                    stopwatch2.Start();
                    Semaphore semaphore = new Semaphore(5, 7, "Ruslan");

                    ThreadPool.QueueUserWorkItem(MoveToListBox, semaphore);


                }
            });
        }

        private void Dispatcher_Tick(object sender, EventArgs e)
        {
            Count++;
            var tick1 = stopwatch1.Elapsed.Milliseconds;
            MainView.ShowTime.Text = tick1.ToString() + " Milliseconds";
            try
            {
                if (Count == 1)
                {
                    var cars1 = FileHelper.JsonHelper.JSONDeSerialization("Bmw.json");
                    foreach (var item in cars1)
                    {
                        NewCars.Add(item);
                    }
                    Thread.Sleep(1000);
                    MainView.CarListBx.ItemsSource = NewCars;


                }
                if (Count == 2)
                {
                    var cars2 = FileHelper.JsonHelper.JSONDeSerialization("Mercedes.json");
                    foreach (var item in cars2)
                    {
                        NewCars.Add(item);
                    }
                    Thread.Sleep(1000);
                    MainView.CarListBx.ItemsSource = NewCars;
                }
                if (Count == 3)
                {
                    var cars3 = FileHelper.JsonHelper.JSONDeSerialization("Chevrolet.json");
                    foreach (var item in cars3)
                    {
                        NewCars.Add(item);
                    }
                    Thread.Sleep(1000);
                    MainView.CarListBx.ItemsSource = NewCars;
                }
                if (Count == 4)
                {
                    var cars4 = FileHelper.JsonHelper.JSONDeSerialization("Hyundai.json");
                    foreach (var item in cars4)
                    {
                        NewCars.Add(item);
                    }
                    Thread.Sleep(1000);
                    MainView.CarListBx.ItemsSource = NewCars;
                }
                if (Count == 5)
                {
                    var cars5 = FileHelper.JsonHelper.JSONDeSerialization("Toyota.json");
                    foreach (var item in cars5)
                    {
                        NewCars.Add(item);
                    }
                    Thread.Sleep(1000);
                    MainView.CarListBx.ItemsSource = NewCars;
                }

                if (Count > 5)
                {

                    dispatcher.Stop();
                }
            }
            catch (Exception)
            {


            }
        }


        private void MoveToListBox(object state)
        {
            var s = state as Semaphore;
            bool st = false;
            while (!st)
            {
                var ticks2 = stopwatch2.Elapsed.Milliseconds;
                MainView.Dispatcher.Invoke(() =>
                {
                    MainView.ShowTime.Text = ticks2.ToString() + " Milliseconds";
                });
                if (s.WaitOne(500))
                {
                    try
                    {
                        var cars1 = FileHelper.JsonHelper.JSONDeSerialization("Bmw.json");
                        var cars2 = FileHelper.JsonHelper.JSONDeSerialization("Mercedes.json");
                        var cars3 = FileHelper.JsonHelper.JSONDeSerialization("Chevrolet.json");
                        var cars4 = FileHelper.JsonHelper.JSONDeSerialization("Hyundai.json");
                        var cars5 = FileHelper.JsonHelper.JSONDeSerialization("Toyota.json");
                        NewCars = new ObservableCollection<Car>();

                        foreach (var item in cars1)
                        {
                            NewCars.Add(item);
                        }

                        foreach (var item in cars2)
                        {
                            NewCars.Add(item);
                        }
                        foreach (var item in cars3)
                        {
                            NewCars.Add(item);
                        }
                        foreach (var item in cars4)
                        {
                            NewCars.Add(item);
                        }
                        foreach (var item in cars5)
                        {
                            NewCars.Add(item);
                        }
                        MainView.Dispatcher.Invoke(() =>
                        {
                            MainView.CarListBx.ItemsSource = NewCars;
                        });
                        Thread.Sleep(2000);
                    }
                    finally
                    {
                        st = true;
                        s.Release();
                    }
                }
                else
                {
                    s.Release(2);

                }
            }

        }
    }
}

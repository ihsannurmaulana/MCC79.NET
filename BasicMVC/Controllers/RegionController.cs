﻿using BasicMVC.Models;
using BasicMVC.Views;

namespace BasicMVC.Controllers
{
    public class RegionController
    {
        private Region _region = new Region();
        private MessageView _messageView = new MessageView();
        private RegionView _regionView = new RegionView();
        private MainView _mainView = new MainView();

        public void MenuController()
        {
            bool isFinish = true;
            do
            {
                var regions = _region.GetAll();
                _regionView.DisplayAll(regions);
                _mainView.DisplaySubMenu();

                int InputPilihan = int.Parse(Console.ReadLine());

                try
                {
                    switch (InputPilihan)
                    {
                        case 1:
                            GetByID();
                            break;
                        case 2:
                            Insert();
                            break;
                        case 3:
                            Update();
                            break;
                        case 4:
                            Delete();
                            break;
                        case 5:
                            isFinish = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (isFinish);
        }

        public void GetByID()
        {
            _regionView.DisplayByID();
            int id = Convert.ToInt32(Console.ReadLine());

            var region = _region.GetByID(id);

            if (region == null)
            {
                _messageView.NotFound();
            }
            else
            {
                _regionView.DisplayByID(region);
            }
            Console.ReadKey();
        }

        public void Insert()
        {
            _regionView.DisplayName();
            string name = Console.ReadLine();

            int status = _region.Insert(name);
            if (status != 0)
            {
                _messageView.SuccessInsert();
            }
            else
            {
                _messageView.FailedInsert();
            }
            Console.ReadLine();
        }

        public void Update()
        {
            _regionView.DisplayByID();
            int id = Convert.ToInt32(Console.ReadLine());
            _regionView.DisplayName();
            string name = Console.ReadLine();

            int status = _region.Update(id, name);
            if (status != 0)
            {
                _messageView.SuccessUpdate();
            }
            else
            {
                _messageView.FailedUpdate();
            }
            Console.ReadLine();
        }

        public void Delete()
        {
            _regionView.DisplayByID();
            int id = int.Parse(Console.ReadLine());

            int status = _region.Delete(id);
            if (status != 0)
            {
                _messageView.SuccessDelete();
            }
            else
            {
                _messageView.FailedDelete();
            }
            Console.ReadLine();
        }

    }
}

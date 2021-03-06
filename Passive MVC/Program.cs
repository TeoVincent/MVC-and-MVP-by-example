﻿using System.Threading.Tasks;
using System.Windows.Forms;
using Passive_MVC.Controllers;
using Passive_MVC.Models;
using Passive_MVC.Views;
using TeoVincent.Utilities;

namespace Passive_MVC
{

    class Program
    {
        static void Main(string[] args)
        {
            int width = 50;
            int height = 50;
            int scale = 10;

            IActionRunner runner = new OverAndOverAgainActionRunner();
            var model = new Model(0, width, 0, height);
            var controller = new Controller(model, runner);
            var consoleView = new ConsoleView(width, height);
            var winFormsView = new WinFormView(width, height, scale);

            controller.Subscribe(consoleView);
            controller.Subscribe(winFormsView);

            consoleView.SetController(controller);
            winFormsView.SetController(controller);

            Task.Factory.StartNew(() => consoleView.ReadArrow());
            Application.Run(winFormsView);
        }
    }
}

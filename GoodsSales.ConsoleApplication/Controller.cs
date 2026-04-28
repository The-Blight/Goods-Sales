using System.Data;
using System.Threading;
using GoodsSales.Core.Interfaces;
using GoodsSales.Core.Model;
using GoodsSales.Infrastructure.DatabaseContexts;
using GoodsSales.Infrastructure.Queries;

namespace GoodsSales.ConsoleApplication;

public class Controller(IProductQueries query, ConsoleView view)
{
    private IProductQueries _query = query;
    private ConsoleView _view = view;


    public void Run()
    {
        var isRunning = true;

        while (isRunning)
        {
            int choice = view.ShowMainMenu();

            switch (choice)
            {
                case 1:
                    var sales = query.GetTotalSales();
                    if (sales is not null) _view.ShowTotalsSales(sales);
                    _view.WaitForKey();
                    break;

                case 2:
                    var productCounts = _query.GetProductsCount();
                    if (productCounts is not null) _view.ShowProductCount(productCounts);
                    _view.WaitForKey();
                    break;

                case 3:
                    var id = _view.ShowInputIdHint();
                    var person = _query.GetPersonById(id);
                    _view.ShowPersonDetails(person);
                    _view.WaitForKey();
                    break;

                case 0:
                    isRunning = false;
                    _view.ShowExitText();
                    break;

                default:
                    _view.ShowError();
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
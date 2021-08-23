using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public interface IInvestor
    {
        void Notify(Client client);
    }

    public abstract class Client
    {
        // properties
        private string _name;
        private double _price;
        private List<IInvestor> _investors = new List<IInvestor>();

        public string Name { get { return _name; } }
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    CascadeAlert();
                }
            }
        }

        // constructor
        public Client(string name, double price)
        {
            this._name = name;
            this._price = price;
        }

        // methods
        public void AddInvestor(IInvestor investor)
        {
            _investors.Add(investor);
        }

        public void RemoveInvestor(IInvestor investor)
        {
            _investors.Remove(investor);
        }

        public void CascadeAlert()
        {
            foreach (IInvestor investor in _investors)
                investor.Notify(this);

            Console.WriteLine("");
        }
    }


    public class IBM : Client
    {
        const string _name = "IBM";
        // constructor
        public IBM(double price) : base(_name, price) { }
    }


    public class Investor : IInvestor
    {
        private string _name;
        private Client _client;

        public Investor(Client client, string name)
        {
            this._client = client;
            this._name = name;
        }

        public void Notify(Client client)
        {
            Console.WriteLine("Alert for Investor {0}, client {1} changed value to {2:N}", _name, _client.Name, _client.Price);
        }
        
    }
}

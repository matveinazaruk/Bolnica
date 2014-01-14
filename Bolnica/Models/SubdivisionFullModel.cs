using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bolnica.Models
{
    public class SubdivisionFullModel
    {
        private string name;
        private string manager;
        private string number;

        public SubdivisionFullModel(string name, string manager, string number) {
            this.name = name;
            this.number = number;
            this.manager = manager;

        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Manager
        {
            get { return manager; }
            set { manager = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

    }
}
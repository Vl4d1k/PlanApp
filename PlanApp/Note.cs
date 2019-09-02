using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanApp
{
    class Note
    {
        int number;
        string description;
        DateTime startDate;
        DateTime endDate;

        public Note(int _number, string _description, DateTime _startDate, DateTime _endDate)
        {
            number = _number;
            description = _description;
            startDate = _startDate;
            endDate = _endDate;
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Commands
{
    internal class GetTimeAndSalesCommand : BaseGetCommand
    {
        public GetTimeAndSalesCommand(string symbol, string accessToken)
        {
            AddParameter("symbol", symbol ?? string.Empty);
            AccessToken = accessToken;
        }

        public string Interval
        {
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    AddParameter("interval", value);
                }
            }
        }

        public string SessionFilter
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    AddParameter("session_filter", value);
                }
            }
        }

        public DateTime? StartDateTime
        {
            set 
            { 
                if(value.HasValue && value.Value != DateTime.MinValue)
                {
                    AddParameter("start", value.Value.ToString(this.DateTimeFormat));
                }
            }
        }

        public DateTime? EndDateTime
        {
            set
            {
                if (value.HasValue && value.Value != DateTime.MinValue)
                {
                    AddParameter("end", value.Value.ToString(this.DateTimeFormat));
                }
            }
        }

        public override string UriStem
        {
            get { return "v1/markets/timesales"; }
        }
    }
}

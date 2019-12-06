using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using tshilobo.Data.Entities;

/// <summary>
/// Author      : Bondo Kalombo
/// Date        :   16/11/2018
/// - This class provides the select lists for Gender, Day, Month & Year
/// </summary>
namespace tshilobo.Data.Services.AuthenticationRelated
{
    public class ListItem : IListItem
    {
        private readonly ApplicationDbContext _context;

        public ListItem(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public SelectList GetDayAsync()
        {
            SelectList days = new SelectList(new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "Day", Selected = true, Disabled = true },
                new SelectListItem(){ Text = "1", Value = "1" },
                new SelectListItem(){ Text = "2", Value = "2" },
                new SelectListItem(){ Text = "3", Value = "3" },
                new SelectListItem(){ Text = "4", Value = "4" },
                new SelectListItem(){ Text = "5", Value = "5" },
                new SelectListItem(){ Text = "6", Value = "6" },
                new SelectListItem(){ Text = "7", Value = "7" },
                new SelectListItem(){ Text = "8", Value = "8" },
                new SelectListItem(){ Text = "9", Value = "9" },
                new SelectListItem(){ Text = "10", Value = "10" },
                new SelectListItem(){ Text = "11", Value = "11" },
                new SelectListItem(){ Text = "12", Value = "12" },
                new SelectListItem(){ Text = "13", Value = "13" },
                new SelectListItem(){ Text = "14", Value = "14" },
                new SelectListItem(){ Text = "15", Value = "15" },
                new SelectListItem(){ Text = "16", Value = "16" },
                new SelectListItem(){ Text = "17", Value = "17" },
                new SelectListItem(){ Text = "18", Value = "18" },
                new SelectListItem(){ Text = "19", Value = "19" },
                new SelectListItem(){ Text = "20", Value = "20" },
                new SelectListItem(){ Text = "21", Value = "21" },
                new SelectListItem(){ Text = "22", Value = "22" },
                new SelectListItem(){ Text = "23", Value = "23" },
                new SelectListItem(){ Text = "24", Value = "24" },
                new SelectListItem(){ Text = "25", Value = "25" },
                new SelectListItem(){ Text = "26", Value = "26" },
                new SelectListItem(){ Text = "27", Value = "27" },
                new SelectListItem(){ Text = "28", Value = "28" },
                new SelectListItem(){ Text = "29", Value = "29" },
                new SelectListItem(){ Text = "30", Value = "30" },
                new SelectListItem(){ Text = "31", Value = "31" }
            }, "Value", "Text");

            return days;
        }


        public SelectList GetMonthAsync()
        {
            SelectList months = new SelectList(new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "Month", Selected = true, Disabled = true },
                new SelectListItem(){ Text = "Jan", Value = "1" },
                new SelectListItem(){ Text = "Feb", Value = "2" },
                new SelectListItem(){ Text = "Mar", Value = "3" },
                new SelectListItem(){ Text = "Apr", Value = "4" },
                new SelectListItem(){ Text = "May", Value = "5" },
                new SelectListItem(){ Text = "Jun", Value = "6" },
                new SelectListItem(){ Text = "Jul", Value = "7" },
                new SelectListItem(){ Text = "Aug", Value = "8" },
                new SelectListItem(){ Text = "Sep", Value = "9" },
                new SelectListItem(){ Text = "Oct", Value = "10" },
                new SelectListItem(){ Text = "Nov", Value = "11" },
                new SelectListItem(){ Text = "Dec", Value = "12" },

            }, "Value", "Text");

            return months;
        }

        public SelectList GetGenderAsync()
        {
            SelectList genders = new SelectList(new List<SelectListItem>()
            {
               new SelectListItem(){ Text = "Gender", Selected = true, Disabled = true },
               new SelectListItem(){ Text = "Male", Value = "1" },
               new SelectListItem(){ Text = "Female", Value = "2" }
            }, "Value", "Text");

            return genders;
        }

        /// <summary>
        /// The List of years, will be queried from the database itself so that if,
        /// we need to adjust the range for age restriction purposes, we can simply
        /// interact with the table, rather than the code in html.
        /// </summary>
        /// <returns></returns>
        public SelectList GetYearAsync()
        {
            SelectList years = new SelectList(new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "Year", Selected = true, Disabled = true },
                new SelectListItem(){ Text = "2007", Value = "2007" },
                new SelectListItem(){ Text = "2006", Value = "2006" },
                new SelectListItem(){ Text = "2005", Value = "2005" },
                new SelectListItem(){ Text = "2004", Value = "2004" },
                new SelectListItem(){ Text = "2003", Value = "2003" },
                new SelectListItem(){ Text = "2002", Value = "2002" },
                new SelectListItem(){ Text = "2001", Value = "2001" },
                new SelectListItem(){ Text = "2000", Value = "2000" },

                new SelectListItem(){ Text = "1999", Value = "1999" },
                new SelectListItem(){ Text = "1998", Value = "1998" },
                new SelectListItem(){ Text = "1997", Value = "1997" },
                new SelectListItem(){ Text = "1996", Value = "1996" },
                new SelectListItem(){ Text = "1995", Value = "1995" },
                new SelectListItem(){ Text = "1994", Value = "1994" },
                new SelectListItem(){ Text = "1993", Value = "1993" },
                new SelectListItem(){ Text = "1992", Value = "1992" },
                new SelectListItem(){ Text = "1991", Value = "1991" },
                new SelectListItem(){ Text = "1990", Value = "1990" },

                new SelectListItem(){ Text = "1989", Value = "1989" },
                new SelectListItem(){ Text = "1988", Value = "1988" },
                new SelectListItem(){ Text = "1987", Value = "1987" },
                new SelectListItem(){ Text = "1986", Value = "1986" },
                new SelectListItem(){ Text = "1985", Value = "1985" },
                new SelectListItem(){ Text = "1984", Value = "1984" },
                new SelectListItem(){ Text = "1983", Value = "1983" },
                new SelectListItem(){ Text = "1982", Value = "1982" },
                new SelectListItem(){ Text = "1981", Value = "1981" },
                new SelectListItem(){ Text = "1980", Value = "1980" },

                new SelectListItem(){ Text = "1979", Value = "1979" },
                new SelectListItem(){ Text = "1978", Value = "1978" },
                new SelectListItem(){ Text = "1977", Value = "1977" },
                new SelectListItem(){ Text = "1976", Value = "1976" },
                new SelectListItem(){ Text = "1975", Value = "1975" },
                new SelectListItem(){ Text = "1974", Value = "1974" },
                new SelectListItem(){ Text = "1973", Value = "1973" },
                new SelectListItem(){ Text = "1972", Value = "1972" },
                new SelectListItem(){ Text = "1971", Value = "1971" },
                new SelectListItem(){ Text = "1970", Value = "1970" },

                new SelectListItem(){ Text = "1969", Value = "1969" },
                new SelectListItem(){ Text = "1968", Value = "1968" },
                new SelectListItem(){ Text = "1967", Value = "1967" },
                new SelectListItem(){ Text = "1966", Value = "1966" },
                new SelectListItem(){ Text = "1965", Value = "1965" },
                new SelectListItem(){ Text = "1964", Value = "1964" },
                new SelectListItem(){ Text = "1963", Value = "1963" },
                new SelectListItem(){ Text = "1962", Value = "1962" },
                new SelectListItem(){ Text = "1961", Value = "1961" },
                new SelectListItem(){ Text = "1960", Value = "1960" },

                new SelectListItem(){ Text = "1959", Value = "1959" },
                new SelectListItem(){ Text = "1958", Value = "1958" },
                new SelectListItem(){ Text = "1957", Value = "1957" },
                new SelectListItem(){ Text = "1956", Value = "1956" },
                new SelectListItem(){ Text = "1955", Value = "1955" },
                new SelectListItem(){ Text = "1954", Value = "1954" },
                new SelectListItem(){ Text = "1953", Value = "1953" },
                new SelectListItem(){ Text = "1952", Value = "1952" },
                new SelectListItem(){ Text = "1951", Value = "1951" },
                new SelectListItem(){ Text = "1950", Value = "1950" },

                new SelectListItem(){ Text = "1949", Value = "1949" },
                new SelectListItem(){ Text = "1948", Value = "1948" },
                new SelectListItem(){ Text = "1947", Value = "1947" },
                new SelectListItem(){ Text = "1946", Value = "1946" },
                new SelectListItem(){ Text = "1945", Value = "1945" },
                new SelectListItem(){ Text = "1944", Value = "1944" },
                new SelectListItem(){ Text = "1943", Value = "1943" },
                new SelectListItem(){ Text = "1942", Value = "1942" },
                new SelectListItem(){ Text = "1941", Value = "1941" },
                new SelectListItem(){ Text = "1940", Value = "1940" },

                new SelectListItem(){ Text = "1939", Value = "1939" },
                new SelectListItem(){ Text = "1938", Value = "1938" },
                new SelectListItem(){ Text = "1937", Value = "1937" },
                new SelectListItem(){ Text = "1936", Value = "1936" },
                new SelectListItem(){ Text = "1935", Value = "1935" },
                new SelectListItem(){ Text = "1934", Value = "1934" },
                new SelectListItem(){ Text = "1933", Value = "1933" },
                new SelectListItem(){ Text = "1932", Value = "1932" },
                new SelectListItem(){ Text = "1931", Value = "1931" },
                new SelectListItem(){ Text = "1930", Value = "1930" },

                new SelectListItem(){ Text = "1929", Value = "1929" },
                new SelectListItem(){ Text = "1928", Value = "1928" },
                new SelectListItem(){ Text = "1927", Value = "1927" },
                new SelectListItem(){ Text = "1926", Value = "1926" },
                new SelectListItem(){ Text = "1925", Value = "1925" },
                new SelectListItem(){ Text = "1924", Value = "1924" },
                new SelectListItem(){ Text = "1923", Value = "1923" },
                new SelectListItem(){ Text = "1922", Value = "1922" },
                new SelectListItem(){ Text = "1921", Value = "1921" },
                new SelectListItem(){ Text = "1920", Value = "1920" },

                new SelectListItem(){ Text = "1919", Value = "1919" },

            }, "Value", "Text");

            return years;
        }
    }
}

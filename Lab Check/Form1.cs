using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Diagnostics;

namespace Lab_Check
{
    public partial class Form1 : Form
    {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string personal = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getFile();
        }

        private void btnGetFiles_Click(object sender, EventArgs e)
        {
            getFile();
        }

        private void btnOpenSoftware_Click(object sender, EventArgs e)
        {
            string [] urls = new string[9];
            //AutoCAD 
            urls[0] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9HjPMeSYfOHAS8iU9CynGBqT6mq8spB5SsxMaIJIad4gKZXs8GlU93g+yqxLlA1xeHP5fNP7hZn51EcE4jX0P+EjQkrPh9uDo1N8Vhx/lZYAl8H73ASBM3i5k3lBcxGS0IIEeV+w532M1DER6nh6o1wJCIzbLs0YrSAJV+CP0aFG7fD3oRxvz6W3bDp+9ryzM8KskIrXiZLWkKEC7gDfp0DBRig/k3+kyDiNQSi0Yrz+U8Y7exdcuScW6dZGntgtQzKfACmRKxtWmDdgTd7pFUFINUCsv8fxOIbWeBAbUfsrVqnuJILfcSGTCbotpr8cN07aS1qtHWtb6kpuoCtz/r+yM8/1aLqiR0pgr0iWs5pQG8Kmf3EQGh9D00Hi1g2gBnRwsrzMKs1mMoX+FCKnYHgsAOPKjeAnLr9IlA3IBz7+vYCz9t6Gyh1hOabHFa3J6wVPJf3rYH6/ns5hP4y/sn6acgyM7oiw27MO6YbycQCiELqWXRHtcW+roAuyT6x4VW2ayskKtFm/UtOwpkX656AScoe4jvbl4ZCI5NAsXlZ+7Kv9SqHdC/HCmhL/FUsthdDbv5vmkTQTg9slYJxjIO3hqJuvMTjx86FCIc/uiyByFN4UlV2RHYXBneN3kXilehV9TFThFuZkRVTJdMnTL3R0O4dgX8AoTFiMb0zAeOUJU+prn5Pys4MnnvGPaBItlotQ968ZzeZ+VeWELwQZvtD2Ey7VBDPEUkqYJyBd/4K1kf8ulevCLOY2XgTazePunNNsa9kRtc0pvMKhzL0A3nySCTpXwK0pMfbAGLW3EqFtrtCS+mtpIpDLkl2wbwwV5dKG6FTBB6s/C7mkMjDPesZKWY8xVPvSKRLVmRe7QovbJqFx1X4TRFsEN7z7GplYvqONcyexJyFKQ87jao6k34eE=";
            //Code Warriors 
            urls[1] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9HtSTMrlM24bfmrOcKXsp18DkrL+ChAdpY3f8dM7pplqBvMv2TO7iuK+79ip14ifcQarWsHAAZhRHmanVaJEo5wlE0az08jFP5sim29UlhTSQi0iVSVqVHuLYC/MMJn1GqAxyRr1e6LZPumbmzixcqlP11RTnX6aqlzRXIx7JxM/lNnC4O2zQYE/WDf3AXhFfp/zk4xD99dVWBUGRzD/XE1vO3cjwpo8wtYoiG+0DKpc5cwZnbtR3LGW9u10yqNspk9+6IecR+7yYvozu23Rpa63tPVBi1PDhKD/nMKeZV5DLB0TKLTmTfnsdX71xe0NVsMf6mIBH9Qi/2772vhwanwZ8q0G9hWu0mngNGifqJBV9byqGzEUUQfT4wiilyfXdirtF7KR1XIfyIC2ClDC/sCCtbfa5WqkRsPJSjZQ9Rsm7";
            //Hyper Terminal 
            urls[2] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9HvhbPHYzDt8wbYYZ6rkUBQCVqqxo573Fj1VDSuau5Lxxm8PJ1Z5rrQqq8+8cFedmsfnG/9kqWI4dsdjm1EMR9A/YgdfwjBg1HZ6joEN27liLG1HgxiM/BqShF8yzerW9dyEV4dUEbSI68MxO08BBzSTa5jHOIOiGN16NsPGBIZMN0/ttyHOpK7qA7iKNkijQ6O9qCMuqYik5qQQ9ahz/4AyFoiWGF1rEiM+QmCFA5NTzvE6PrQZwFzFfY6/Q1myMBpF85XvahQvr1KcmwTkRptT2nob5PIrHhJnVydjqf1B56qGAz8/fkH/e4U2QyxaOW3WQ41F8m6cdRYsnf9iNuVQQr8Ekx5IhpRg1bL2aDZ+oAKt0pHWRQULxLuqegs9V1On3lIbFeuBtF2IDVHUHPYf10EJbuEoreoWC3dD+gRYM";            
            //Matlab 
            urls[3] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9HncRU1Rrv3cD+p/b2Cl4T7iEeKoW39fUtRgcMVl/fYBeusUafii7XZMzn8Bsjd8gml4eiDohCYivtZ1pmWhXfh9UoY1WbYdJ3tIYV03xbAq5ctKPwBUWjAFNdptH87jT/hXOZ3x9tCEw/60xuBRkSVA540U1G0kCNmcRH+iX6pB5T/Ua2h41Op2IZ7OThBU1SCayXHe0S4tv8Y9DPMteRYhm1ffhH+eVj05QkYV2Xub5ZHuXscA0x4e9P42O7tJDc16CwHhDClNtYf2XvM4l7sRmPgaav4lXrvw3eBQdhq9nZA+wSBkowwJk4snU2t9mPoqrCGT3ZhblfC6vy+deSjftlRg3TJARWP7a+7xNvpT1AjxGpCjbNkg6Th95MKVuILW6AtaQoycXgS1Z5jYIkB572c2FeFH4F1Q+3hsyBHY4";
            //OrCAD 
            urls[4] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9HjHLZRc6msRlhOCJQOfA5hRQWbnkBs92k9omKLlaqvgR9sYNQV/eNYq5I785ctP145xf/0B1rARQwYdsL7dkqNqmqx096pSwJSFouEL86W17EgYw9ZJ8P6Yw8omMExgc4NuW1pu492H9tI0n0yllzprHNWPQAMX0BN1GvrN0HbZgeREelGNYsMlNVj7oYRyUtqBb1Ik0Cru6hNf6OP5pgnh6eErQyKX7bJaLNaDuJ/w/cLGFVlfDmwb6M1/1rMGOaV4dVMroNFUiR85asryi+2dOhswUpbWvuhz5+LSH3Bo6kNVkOAlSq9Wh4TITtIpBap/j4WqFb2r5K8K+0osm3l0LwC2jB68rZ2rXDstkNo8P0A7qPsXBGA/FqB5PfRNBk3bH+2pKmJ6/oxgdqhbvmRmNBdEr9pPuYe2k6BtOA23r";
            //Pads
            urls[5] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9HpuRhfNehfFhVy39Mdlu6+sQJgqv0m9rRK/KQQdMom81tKu8LhaD/Nizq0n5+Wz+iJfjNHzeI+hxGYg4JFhmWdo+xSmuq3TVmVxXrXnTTiiOSQQvDmv6X4CFtbTgELXH5PTR7ShS1v8rIH4/ht3R9a6f6OhtwINqSAuRv+zs2A8omD/jOE3OKC6neyskGEhLfx/1rV+cNxCn3RSGyM5s0iGCA6bhMPQEuYXeYy+40sS2psJmTkWU4kCpuUyAwcKpx2brvy0GaAfKuLE0GLpJlnbfMlHuzUWvM+4euxbcCE0m1Wr4Je5lbzhS7o1+EpLwcfDbAUKfvKG/EyYD5dDKwfFbTdYJgSCfQI5Xmwgy+vaOSA3+Cu/NyGuDW0EG3cWqBagVOsOGw2/5EvTLw+T0Eefv0gekfKiLy62pUWvM/hjt";
            /*
            urls[5] changed by Sushen Dec 10, 2018
            The old link as following:
            urls[5] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9Hs1Drqo04jK81m80qqPPzuMKkpjF9Sz4Xr+oWrSpmb6AOTfRdCiuzXk8LN1883sHuZDTC9iACEkkk4ZO70b56t+ntW98GSKwqXu1DbSCviyxlxySw89gcIAy8CuKZrBXl7KcJYXcW2YpZkZjDefF8k/SAIu+Zcu8xhQq5JVGnYuiPv+3/2m/dVJF+SE83jfa2SrI0a62foYsFGpo53+pMhbLGrXnqMQakgYK6hETrKRKNjBaHFXZv74Z5Mgf6UZq2XJO+SaJN/pRx2dzoj0CuICXn3b1OKN8v86uAn9ocNX9ziAZPD2f81ppndBCb8v/RLbPYg2lSJSXC9N5SHbX1BtI9QuSL6NGd1vdbkgc8YwklGFQNnc/1zM9NH26GAQEucjQExATijBNhLEGU59xxOfyK743rEd8hB2fWFFr7t1JhwFM2Cgdaquse+jnZlX69ZA9FFrOfSls3VO3BIv7cngQQESPjm0H/44GBPl4OOWxdha57C7TbitfEWb8NQkCeQvxVaVz+Uq78l7ytceS9Y69R6UQOdLRIGfuhxredAddRyey1d9yaEPe1nJi7yJyQClfarD0NblTR2wjRjl5meN7nL2EdnmobzE5JPebZZhGdm/dU+jPYYrZey+kDJSAFsg0DMRxxVp5TgS91AkzIY4TU+FloYB7OQBVUc17klqlfl20jZb5k4D34FltEv5+JK6l4nb2BN1xySKpURaOaiTI2svBV2UcpO5t0idmLLnck6FVwzEHmkhebtSRitH7A8gbPPdxT0JFeElBASiOHOvMEjiKJFe15uQKRsH+CHU+TwnyZu+n634rmkdQf2xEx/nO7WWViQ4/tOzRpUNTASCZmMy34RyhvDnL1U548eeXQzWmOCDbIvU0Fb6IEuCS4aSUQbXGPy5lSvxwkfYdE/w=";            
            */
            //Quartus 
            urls[6] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9Hpf9lxvWHcoyDtUWeway50C6Er6rKKH3ZtS2zFpNwiThu3j4YjCN5guRul4z2n9Lb3ZBm0glHFLmdM8hfDi+nLGLAk6zGz1N1no/YTr3OOlRZLIVJG9DEotUkdNEWMcy8BLwdM/ZYAm4Yu8pu9tT85Iz3cLTCE/BF+TJFcrI4xtI1wyO+k6gSzzBjg4fi5GqdyIJc8xfE5i44uTuYV/dwuvcy2DNOumy3Lo4GeQEjMVSX9D0oNNU9rdBbu0c32CxvEpgZejUrTTcjKIehxpjwc7itOM0QzJ87ELh4+rIbaHN5IIvjBi7AxDLwBbUbE7oi6+9WueRZQ1iusQuoEcA47ZfZUbStOoII2sKTPxROQFfNo/ZrcfRtBuOrNYo7Ck4xNEAOiL2fqxsX+1FgYR+dfMpVGJtBZF5tfb2MCErePl/";
            //Spyder 
            urls[7] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9HhJt8DgUO+ugyAhj6VTBmE0GjIeJXfxBERvADxJHIjAWaWaEHCJVDNElBuIO3DmeHaPIo172hwXvdEwZPWlkxVdPLwVokq7wPzAx6X2Zdh4KNhlsXeP34kZnRm3nKWwYhhiiT8CCcisnyzJYLKMed+SBAeNPij/PxV+cX3l57jfgom5YhgREAX41Kr20TRtvv5zu1r8uHHcavHHaqk1+ohuaow7wj5cVPsL68fofmFyycyRmvZchHGneTgKUDUHR4jGmgv08uLaN4oGF8SUeCpX8ToQMYl+VSdcFRHy3GVcXEzvweZWudHAA+YPeogeF74cqa9mAcNVjWs92OHBKbGjOpoHNvPSGKDf+NTs/HHmgls8E9+cBTR6Je6OvSQ6R3Kpk5oe3NZThh6A9mzGHX1UIfrt00deyVG17hERcI/U3kzHrJsIcplepq947Sj0+QmY65iHqC778BiXD9G3oTbWXWfAtFS5GHXl6DDJFPvpGllYOyOKGgFlmW71N6KVUdpslfoOClZXf9BQ9pDKLuId3OXWt9riUdB7NpoAckX87q95y3Frg8VSHUKDZ9PtwHAt2bpYQXCkLyv0iNxAtU02+vtr0ImupdxkVlzJiupGcbHIgkPIvLi3vcZEci1Qs65c0chl2/2ew5SpvyKB60DKuxvvM7Fd+B8NmLim/6wWEpwPpI9HVt74jmhYNKQDSDYwq9I1FI95YY9FhY7ip6ghBIHGTZpNU3Tbgr8FVqV8SEUW7FggKqGoM19v0BA8/gCaiL/DNxqK5DVcB7VbYleyCb7e/RfoQ2SVLHPjKK3bFMGpwwdL7TXgEgsTDQm9O8etuyHMBVy5RdXYLPfgCWLD/2gvJ1lzsgMKNbGJKzYDFWKfVyLSUo0gwGI/J3xBGAIywAaychlCogqgSfnIgfMk=";
            //VSA 
            urls[8] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9Hl1FI9FB75phssmhAaBvDQAIpsn8ooPiikTE0eY2Y+Rgf+yWJI/b+dtJyrLLmOjy5ZNwn+lmPZ051yWz/TmOgHplPX/u/zPGCgn+FBvgFqac4jM5Ecu2JLGuxLu+0ftt3QzbHe4bE5nDl8sQ2+LwLn+s5VVsfZzpwEyYZRZiPmYFE6q8zM/bYYbrvsq4401AMt1YmJtZwLV7pXfOyj1QwrxFeHYEj2YxKNrv27eQXdQ0P+QO7/RRzHkGXfMegNxtmJ2H8bJErXOHzfRwGVU7uUTWuCjb26IrJzOOS7Arhz3YG6pjTDpYZ0Qczyzae1UHXDzk4VsDKa65Wu1JDEmxscmpca8e0uyB9ouI1RHqe2L8HBuDUeJjiVfuI0SZrI9SR9MdbcTgLo30T7BAWaZGG1h2M2Mqb9Ju7QoIb0HRWS/EXTV0NoJjOjkrXpts/7qY6+t25f9X6V/cLXG6igIdT7n6MdA7t5eT9WQ75XKdzvrYsqOqpKEi2yOTIn3nHw6zDPLIAupj9AJKtF607/7f9mv8G7wel/QjczexELUJA+rsO40dR8mDEPLBoITZjdHIsPXpwfwczxBPAIGQF6DT33B6nqzlK+LSQSIUo9kDf2BRiXAeBhk0gFvx5JuqFIjswyLTvrkozoAjamVaGtBG11EwnJBxzFL26NGSWvJUHn62quG6Hs3hqEuKeBPsxrAzT9PQwkPRIveR6AxxAJ5ldm/rBzm/hzb1FbawRsU+zux+U+8U7PMcaTFm6iS85f2CZYuIXTNGw/qlF9WZJv8ug3NA6+eEToLnsdTCcFve841+XEUUxsjPsHxRwGmAedWmHOZxO7jOZJYlgjZ2aBDp97dAZ1e4e29lgYahMGIlHlhXVNARhnZodJTMxtVYSkr9U5S3Nxjq+mBg3AH7zskFd3A=";            
            //LVServo 
            //urls[9] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYO644d4N5of6GS+1LMNk4r3/hCIJ3sz6kwvbVrVdpTkYfPjtRCN3Ue/wLOCVrmLWmXXVtIrrlHhUl4EU4CN348+LKaBs6TtwTJStK9nSrImO+WBLJZ7AEG1AsHgen1lWa4LLfYn8DXZ5tXdNA1oTXxi6f7vwEk120k59QNN2oSRtSAksvf1KGaCod3j0/DojHSx0cqAklQqKpl65X0GHl8cZUbsOKZM+Q/6/nopS4KYQfg+3+x2Jxkpne4cGTG8wjgLg2/VyBv/fsHZ+/ISDBsc";
            if(rBtnOpenAll.Checked == true)
            {
                foreach (string url in urls)
                {
                    System.Diagnostics.Process.Start(url);
                    Thread.Sleep(1000);
                }
            }
            else
            {
                List<string> selected = new List<string>();
                foreach (int i in listSoftware.CheckedIndices)
                {
                    for (int j = 0; j < urls.Length; j++)
                    {
                        if(j == i)
                        {
                            selected.Add(urls[j]);
                        }
                    }
                }
                string[] array = selected.ToArray();
                if (array.Length < 1)
                    MessageBox.Show("Please select at least one software");
                foreach (string url in array)
                {
                    System.Diagnostics.Process.Start(url);
                    Thread.Sleep(1000);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Process.Start(desktop + @"\Lab Check Files\ALTERA_TEST\TEST.qpf");
            Process.Start(desktop + @"\Lab Check Files\DE1 TEST\hypertrm.exe", desktop + @"\Lab Check Files\DE1 TEST\COM8_19200.ht");
            Process.Start(@"C:\Freescale\CW MCU v10.6\eclipse\cwide.exe");
            //System.Diagnostics.Process.Start("software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYO644d4N5of6GS+1LMNk4r3/hCIJ3sz6kwvbVrVdpTkYUovDi1ump+j9S1pw5jCpGSH5fmbWInjPmXul0T/SLwKGNHFISuLpzGYAH/69jQ+m463mmLNrpD9QENzrsTR75THGsLKkXDkhGiGRXDHjLLcf8JmmNAzDT6cT9kcRtbiSqGsyct9e0t5g7MYnNmWL3FOeQ7ZY7PvHkMnipCwH9/x2KvwAjNgunsnjeMf7v0l5gd0MEF1INWC51bb4UZRmR0=");
            importDE1();
        }

        void getFile()
        {
            //string zipPath = @"Lab Check Files.zip";
            //Changes make by Sushen 
            string zipPath = @"c:\Insight Files\Lab Check Files.zip";
            string extractPath = desktop + @"\Lab Check Files";
            try
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                MessageBox.Show("File(Lab Check Files.zip) not found!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            
        }
        void importDE1()        // overwrite code warrior workspace files
        {
            string sourceDirectory = desktop + @"\Lab Check Files\.metadata";
            // Win 7 Image
            string destinationDirectory = @"C:\Users\common\workspace2\.metadata";
            // Win 10 Image
            if (Directory.Exists(personal + @"\workspace"))
            {
                destinationDirectory = personal + @"\workspace\.metadata";
            }
            try
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDirectory);
                foreach (string dirPath in Directory.GetDirectories(sourceDirectory, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(sourceDirectory, destinationDirectory));
                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(sourceDirectory, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(sourceDirectory, destinationDirectory), true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}

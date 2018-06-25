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
            urls[0] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9Huoodi1Qu5CwI4l4j1I1zuXkcORfCLYzuwxslSosaoL5xm2nPzUXg+K2xTwUyUI6/hTmhtkr3J+SIKFC7PDPJxSZi0qBWyBUp+43XfH6oVKwxj8ckuTiAaAv1Wj2ip+gLsoFDUU1aJ0oYrB2YjLdHRSYht9WopaBb2Zs5plYI6tOvntaxxL4TqmLmJgxj5/9ZQ0XshIvXI2kMlthsJDPF/Rs5ArAL9rgjxXibqvG2oEcctXtH5+1UrOELJrclgp8QY+5RMew2eU8FYiwb5N/AXLVGmomrBtTLAOHnhhAG1ug3H64cG/XUzgbUPhjeEOsovv+zR5iGiDDkucR4L7raUx53HblJids7xUn5eUj4uk8IUhX5wgD8rpcfxCceFOlkIlngFZ0JnUv4pa4AQCdkbNtWJCWP7lQJk81hMrqpx5Z";
            //Code Warriors 
            urls[1] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYO644d4N5of6GS+1LMNk4r3/hCIJ3sz6kwvbVrVdpTkYUovDi1ump+j9S1pw5jCpGSH5fmbWInjPmXul0T/SLwKGNHFISuLpzGYAH/69jQ+m463mmLNrpD9QENzrsTR75THGsLKkXDkhGiGRXDHjLLcf8JmmNAzDT6cT9kcRtbiSqGsyct9e0t5g7MYnNmWL3FOeQ7ZY7PvHkMnipCwH9/x2KvwAjNgunsnjeMf7v0l5gd0MEF1INWC51bb4UZRmR0=";
            //Hyper Terminal 
            urls[2] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9HohDV2rAg4bJkNjzgam7qo2sCPdC7al08ZNH5GK5gPfbhk/1yZRMxR/yupZXAYMHDGjii9o0rEwPb0T78rEbqgAIJWYkD19SZ58wT9ikNPw1uX6XcuLguH+O+I2fghaMN2mS8cxwxnbUoMsq5SyMIvvm6v0xh9y074axAQRxTpJliYrxNlSj/MwQSL47j9lriRHzMIK+pa19pyFrF3+RjofndX0muqqkKcbWhOLg3oBCVLRFyqS45KcO5N9qBNJ51ojEqPhCpjAzvFuuZ47YO+9QWlUFYKPGOjpNS/GLYRjJGUVYy3d5Eobm1OyigsKTro8aXbjoeKQepfTpQ/znZsOvUHJpukmjrZXg4Cf1t3Q1W0rZZR9GKXngS06b3/IEcZNLycbOwO7uunpQAfDgmItUqaMm1dq59awx4UKEDf8/";
            //Matlab 
            urls[3] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9HncRU1Rrv3cD+p/b2Cl4T7iEeKoW39fUtRgcMVl/fYBeusUafii7XZMzn8Bsjd8gml4eiDohCYivtZ1pmWhXfh9UoY1WbYdJ3tIYV03xbAq5ctKPwBUWjAFNdptH87jT/hXOZ3x9tCEw/60xuBRkSVA540U1G0kCNmcRH+iX6pB5T/Ua2h41Op2IZ7OThBU1SCayXHe0S4tv8Y9DPMteRYhm1ffhH+eVj05QkYV2Xub5ZHuXscA0x4e9P42O7tJDc16CwHhDClNtYf2XvM4l7sRmPgaav4lXrvw3eBQdhq9nZA+wSBkowwJk4snU2t9mPoqrCGT3ZhblfC6vy+deSjftlRg3TJARWP7a+7xNvpT1AjxGpCjbNkg6Th95MKVuILW6AtaQoycXgS1Z5jYIkB572c2FeFH4F1Q+3hsyBHY4";
            //OrCAD 
            urls[4] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYO644d4N5of6GS+1LMNk4r3/hCIJ3sz6kwvbVrVdpTkYYz1k+d67FJyPyM9qBIPzStn3OlZHfH0/ucP96BijNtwmrTJMRu/lEzAKCqSTZyjtSdWHgrY6uzrREhfnqiuz2UXTTygRsg44hIc/DU1EXe1wmaLmweTBAmXFiiTVDITGUDSr+tY5//eyYRQELkp1BzbQnY6aYU1itNvb31TQNGY0hszcMM3cnJYn+Urk7zMKjyqRuR4+xoLk1kE9r6sU4c=";
            //Pads 
            urls[5] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9Hv+aHZknBm0wVEFx65wqbkjv/6FrLqZR1hRuO7E0i5tIhkvMIBrvhrFRMkBKit0JNLjSYtXGOZLVAm6wYwEFW/MLIfZOUNcBCBDFbVFz6BSNgrKk68pmR182fJK7N/Vy21e8JrivWDRhcBbEwyKkr5WmdKpbVLwoMqVQiISVus8udgwCMPMhglvWDQVh5m9HAgqkphrGirylHm3KemtzYLNCt4Box8duyVofm/RPb2WNcatBTVSV6M+9j0qfKcmu8aDPTGo338FT/R2JU8oUPgRyagT3qCoJxIcgifBtA/6rUjK9xF1IPPubfEWup/zuSJZJsnG57430CzpjhqFF8rZCgS7u0v6dhcWj2hhyGaGZZV/TL+J84c9WkTK0FGOzm3Xk3OImAZ3QUWYP62yyBXgMZ3T+VgAQPJcTmBc8cqRh";
            //Quartus 
            urls[6] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9Hpf9lxvWHcoyDtUWeway50C6Er6rKKH3ZtS2zFpNwiThu3j4YjCN5guRul4z2n9Lb3ZBm0glHFLmdM8hfDi+nLGLAk6zGz1N1no/YTr3OOlRZLIVJG9DEotUkdNEWMcy8BLwdM/ZYAm4Yu8pu9tT85Iz3cLTCE/BF+TJFcrI4xtI1wyO+k6gSzzBjg4fi5GqdyIJc8xfE5i44uTuYV/dwuvcy2DNOumy3Lo4GeQEjMVSX9D0oNNU9rdBbu0c32CxvEpgZejUrTTcjKIehxpjwc7itOM0QzJ87ELh4+rIbaHN5IIvjBi7AxDLwBbUbE7oi6+9WueRZQ1iusQuoEcA47ZfZUbStOoII2sKTPxROQFfNo/ZrcfRtBuOrNYo7Ck4xNEAOiL2fqxsX+1FgYR+dfMpVGJtBZF5tfb2MCErePl/";
            //Spyder 
            urls[7] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYMOjKuutCPxAPrO4avJX0K/jaNSP9uP0AjVJs28lurkRMYz+GSujo/v80FcR9getD23qgY2vdWNN24mHxoCY5EplULRfYo1W6cKyFqEk5ocwXFjhgt98Ht79znDSM06U1aB2QSm6kVqPuUWMDmKt07tvOZI0GE9CiIe7d2FYAX9HhJt8DgUO+ugyAhj6VTBmE0GjIeJXfxBERvADxJHIjAWaWaEHCJVDNElBuIO3DmeHaPIo172hwXvdEwZPWlkxVdPLwVokq7wPzAx6X2Zdh4KNhlsXeP34kZnRm3nKWwYhhiiT8CCcisnyzJYLKMed+SBAeNPij/PxV+cX3l57jfgom5YhgREAX41Kr20TRtvv5zu1r8uHHcavHHaqk1+ohuaow7wj5cVPsL68fofmFyycyRmvZchHGneTgKUDUHR4heX/RCPU/z3WvfqCN2DX4K0SV+ftdIiJ0HXL0ldHke5vIbyt6Je+GqLiSLrkrzn0P1fQKcntgdjZFrIjfEgVW4+Rt84+m1pdrIsgxq3qHfHsqzAc2ETn7bvHpPV8OCvgAztQ1Gx+DlsUs17ZM7rw/ydsP6ex3D0BpwyKHsXz7Fy";
            //VSA 
            urls[8] = "software2hub://RpLE22+gvQBSQC0oHGDNQSGnjf++3j8optf1Gt3vBt9x0FVKmCFxQeSNwNOUNNlT3pM9mnLAo5ghkF/Zy43Hpkcbz5aYdEbcwA9ik6+FhIUAtZOUU63EpgyeqweeYBzQVYmMK5B2rsHCGbgiwjFwPEPA2KYnawcBiJXy+tx6rYO644d4N5of6GS+1LMNk4r3/hCIJ3sz6kwvbVrVdpTkYUWbL3OanqADMgIaVx0uZA+VFYog4yuP52iwWhoRn+x03rAKe2zj60RuKFjCP91CeOmAosNiYci+dUcuRO/FVDUhi96I2Z0TjtN8Oi0IsT8gfgbodWVewkkv5M81iGBUjEeyBYLYJYh+4FrSGAAJBHXH36RQHIUKSFODXuPUVItkZPK7wNLz0NfLyhil+iYqDVxmaxHQyn4h2JBSdbu6qbS3O2BZIzcMSo7VtNoJAyeat9lHqDYw8xtPZ6EwXK5AFtMdbDj5rSgDJTrDIiC5m1DY9bM/el7Bab47vyM8VPbbrj4hTMjLuV3gmnNa26Eg6w==";
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
        }

        void getFile()
        {
            string zipPath = @"Lab Check Files.zip";
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

            }

            string sourceDirectory = desktop + @"\Lab Check Files\.metadata";
            string destinationDirectory = @"C:\Users\common\workspace2\.metadata";
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

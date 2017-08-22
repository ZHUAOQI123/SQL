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
using Microsoft.VisualBasic.Devices;//重命名方法引用的命名空间，暂时还没学
using System.Xml;
namespace unit_资源管理器
{
    public partial class From1 : Form
    {
        public From1()
        {
            InitializeComponent();
        }
        public string sourcePath = "";
        public string destPath;
        public string action;
        public string type;
        public int x = 0;
     
        private void From1_Load(object sender, EventArgs e)
        {
      
            //获取计算机中的所有驱动器的名称
            DriveInfo[] drive = DriveInfo.GetDrives();
            //循环得到的驱动器名称建立树节点
            foreach (DriveInfo item in drive)
            {
                if (item.IsReady)
                {
                    //每循环一次建立一个树节点
                    TreeNode node = new TreeNode(item.Name);
                    // 给 Tag赋值
                    node.Tag = item.Name;
                    //在TreeView 控件中绑定建立的树节点
                    tvDrive.Nodes.Add(node);
                }
            }
           LastCloseForm();
        }

        public void LastCloseForm()//加载上次关闭状态
        {
            string temp = "";
            XmlDocument xml = new XmlDocument();
            xml.Load("资源管理器\\ClosedKeep.xml");
            XmlNode xmlnode = xml.DocumentElement;
            foreach (XmlNode item in xmlnode.ChildNodes)
            {
                temp = item.InnerText;
            }
            string[] str = temp.Split('\\');
            TreeNode opennode = new TreeNode();
            foreach (TreeNode item in this.tvDrive.Nodes)
            {
                if (str[x] == item.Text.Substring(0, 2))
                {
                    this.tvDrive.SelectedNode = item;
                    updatalist();
                    opennode = item;
                }
            }
            ++x;
            Foreachnode(x, str, opennode);
        }
        public void Foreachnode(int i, string[] str, TreeNode treenode)
        {
            int count = str.Length;
            TreeNode opennode = new TreeNode();
            foreach (TreeNode item in treenode.Nodes)
            {
                if (item.Text == str[i])
                {
                    this.tvDrive.SelectedNode = item;
                    updatalist();
                    opennode = item;
                    if (i <= count)
                    {
                        ++i;
                        Foreachnode(i, str, opennode);
                    }
                }
            }
        }

        //窗体加载
        private void tvDrive_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //获取在TreeView中存在的节点
            TreeNode node = this.tvDrive.SelectedNode;
            //清除节点的所有子节点集合
               node.Nodes.Clear();
           //清除ListView控件的所有内容
             this.lvFileList.Items.Clear();
            //获取节点标签
            string path = node.Tag.ToString();
            // 获取对应标签drive的节点下,下一级所有目录的名称
            DirectoryInfo dir = new DirectoryInfo(path);
            // 对应标签节点下所有目录的名称放在集合中
            DirectoryInfo[] childDirs = dir.GetDirectories();

            foreach (DirectoryInfo item in childDirs)
            {
                TreeNode childNode = new TreeNode(item.Name);
                //获取所有标签的名称
                childNode.Tag = item.FullName;
                node.Nodes.Add(childNode);
                // 当选择树节点时，在ListView控件显示树节点列的内容
                ListViewItem lvi = new ListViewItem(item.Name);
                lvi.SubItems.Add(item.LastWriteTime.ToShortDateString()+""+item.LastWriteTime.ToShortTimeString());
                lvi.SubItems.Add("文件夹");
                lvi.SubItems.Add("");
                //获取完整目录
                lvi.SubItems.Add(item.FullName);
                this.lvFileList.Items.Add(lvi);
              }
                FileInfo[] files = dir.GetFiles();
             foreach (FileInfo item in files)
             {
                 // 当选择子节点时，在ListView控件显示子节点列的内容
                 ListViewItem lvi = new ListViewItem(item.Name);
                 lvi.SubItems.Add(item.LastWriteTime.ToShortDateString() + "" + item.LastWriteTime.ToShortTimeString());
                 lvi.SubItems.Add(item.Extension);
                 lvi.SubItems.Add((item.Length / 1024).ToString() + "KB");
                 //获取完整目录
                 lvi.SubItems.Add(item.FullName);
                 this.lvFileList.Items.Add(lvi);
             }    
        }

        //复制功能
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            //获取源路径
            sourcePath = this.lvFileList.SelectedItems[0].SubItems[4].Text;
            //获取文件类型
            type = this.lvFileList.SelectedItems[0].SubItems[2].Text;
            action = "复制";
        }

        //粘贴功能
        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            //--在tvDrive控件上节点
            TreeNode node = this.tvDrive.SelectedNode;
            //获取源路径          
            destPath = node.Tag.ToString();
            //判断源路径下文件类型
            if (type == "文件夹")
            {
                //调用方法
                CopyDir(sourcePath, destPath);
                updatalist();
                //删除源文件夹
                if (action == "剪切")
                {
                    //true是重点
                    Directory.Delete(sourcePath,true);
                }
            }
            else
            {
                //如果不是文件夹类型就没有子文件，可以直接复制过来
                FileInfo file = new FileInfo(sourcePath);
                destPath += "\\" + file.Name;
                File.Copy(sourcePath, destPath);
                updatalist();
                //删除源文件
                if (action == "剪切")
                {
                    File.Delete(sourcePath);
                }
            }

        }


        //剪贴功能
        private void tsmiShear_Click(object sender, EventArgs e)
        {
            //获取源路径
            sourcePath = this.lvFileList.SelectedItems[0].SubItems[4].Text;
            //获取文件类型
            type = this.lvFileList.SelectedItems[0].SubItems[2].Text;
            action = "剪切";
              
        }

        //写一个方法，使用粘贴.剪贴功能时，选择文件夹的时候使用
        public void CopyDir(string sourthPath, string destPath)
        {
            
            //DirectoryInfo用于创建枚举目录和实例目录，创建源路径sourcePath下的（dir）实例目录  
            //----------1. 例如sourthPath=C盘（DirectoryInfo 返回当前目录的子目录）
            DirectoryInfo dir = new DirectoryInfo(sourcePath);
            //拼接目标路径,新的目标路径=目标路径+实例目录的名称 
            // ---------例如： destPath=D盘\照片集文件夹\一家人文件夹
            //---------2  新目标路径（path）=destPath=D盘\照片集文件夹\一家人文件夹+C盘下选中的子目录的名称（Name是文件名称）
            string path = destPath += "\\" + dir.Name;
            // 在指定路径（path）重创所有目录和子目录
            Directory.CreateDirectory(path);
            //创建files集合，存放dir目录的选中的目录列表(FileInfo 返回当前目录的文件列表)
            FileInfo[] files = dir.GetFiles();
            //  将当前选中的文件复制到指定路径
            foreach (FileInfo item in files)
            {
                //循环 拼接目标文件位置，复制源文件到目标文件位置
                string a = path + "\\" + item.Name;
                item.CopyTo(a);
            }
            //创建数组childDirs为实例目录dir下的子目录的集合
            DirectoryInfo[] childDirs = dir.GetDirectories();
            foreach (DirectoryInfo item in childDirs)
            {
                //循环子目录，将所有文件复制到指定路径
                CopyDir(item.FullName, path);
            }
           }

        //删除功能
        private void tsmiDelect_Click(object sender, EventArgs e)
        {
            //获取文件的位置
            sourcePath = this.lvFileList.SelectedItems[0].SubItems[4].Text;
            string type=this.lvFileList.SelectedItems[0].SubItems[2].Text;
            if (type == "文件夹")
            {
                Directory.Delete(sourcePath, true);
            }
            else
            {
                File.Delete(sourcePath);
            }
            updatalist();
        }
       
        //-----------------------------------重命名功能
        public string oldname = "";
        private void tsmiRename_Click_1(object sender, EventArgs e)
        {
            oldname = this.lvFileList.SelectedItems[0].SubItems[0].Text;
            //应用vb命名空间的BeginEdit（）方法，重新编辑文件或者文件夹名称      
            this.lvFileList.SelectedItems[0].BeginEdit();
        }

        //重命名——重新编辑文件或者文件夹名称后发生
        public string newname="";
        private void lvFileList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            //获取编辑后的文件夹或者文件名称
             newname = e.Label;
            //把文件夹及文件不允许包含的字符放在一个集合里
            string[] uncount = new string[] { @"\", ":", "/", "*", "?", "<", ">", "|", "\"" };
            //循环uncount集合
            foreach (string  item in uncount)
            {
                //判断新编辑的文件或者文件夹名称是否包含非法字符
                if (newname.Contains(item))
                {
                    MessageBox.Show("不允许出现非法字符");
                    return;
                }
            }
            ReName();
        }

        //重命名的方法
        public void ReName()
        {
            //获取被选中文件或者文件夹的路径
            string sourcePath = this.lvFileList.SelectedItems[0].SubItems[4].Text;
            //获取被选中文件或者文件夹的类型
            string type = this.lvFileList.SelectedItems[0].SubItems[2].Text;
            //解决方案资源管理器的引用添加using Microsoft.VisualBasic，
            //调用命名空间using Microsoft.VisualBasic.Devices 里面的方法，实现Computer实例化
            Computer computer = new Computer();
            if (type == "文件夹")
            {
                //computer里的FileSystem用来获取文件或者目录的属性和方法；
                //RenameDirectory（）方法，第一个参数放源文件路径，第二个参数放新文件名称
                computer.FileSystem.RenameDirectory(sourcePath, newname);
            }
            else
            {
                //computer里的FileSystem用来获取文件或者目录的属性和方法；
                //RenameDirectory（）方法，第一个参数放源文件路径，第二个参数放新文件名称
                computer.FileSystem.RenameFile(sourcePath, newname);
            }
        }

        // 加载的方法，用于每次操作后刷新数据
        public void updatalist()
        {
            TreeNode node = this.tvDrive.SelectedNode;
            //清理子节点
            node.Nodes.Clear();
            //清理listview控件的数据集合
            this.lvFileList.Items.Clear();
            //实例化获取树节点目录集合
            DirectoryInfo dir = new DirectoryInfo(node.Tag.ToString());
            //实例化获取子节点目录集合
            DirectoryInfo[] childDirs = dir.GetDirectories();
            foreach (DirectoryInfo item in childDirs)
            {
                TreeNode childNode = new TreeNode(item.Name);
                childNode.Tag = item.FullName;
                node.Nodes.Add(childNode);

                ListViewItem list = new ListViewItem(item.Name);
                list.SubItems.Add(item.LastWriteTime.ToString());
                list.SubItems.Add("文件夹");
                list.SubItems.Add("");
                list.SubItems.Add(item.FullName);
                this.lvFileList.Items.Add(list);
            }
            //实例化获取树节点文件集合
            FileInfo[] fil = dir.GetFiles();
            //实例化获取子节点文件集合
            foreach (FileInfo item in fil)
            {
                ListViewItem list = new ListViewItem(item.Name);
                list.SubItems.Add(item.LastWriteTime.ToString());
                list.SubItems.Add(item.FullName.Substring(item.FullName.IndexOf(".") + 1));
                list.SubItems.Add((item.Length / 1024).ToString() + " KB");
                list.SubItems.Add(item.FullName);
                this.lvFileList.Items.Add(list);
            }
        }
        // 新建文件夹
        private void tsimFile_Click(object sender, EventArgs e)
        {
            //获取tvDrive控件上的节点
            TreeNode node = this.tvDrive.SelectedNode;
            //节点标签赋值给name
            string name = node.Tag.ToString();
            //实例化一个新的目录（对应name名称），相当于节点C盘D盘
            DirectoryInfo file = new DirectoryInfo(name);
            //获得file目录下的所有子集合
            DirectoryInfo[] ChildFile = file.GetDirectories();
            int n = 1;
            foreach (DirectoryInfo item in ChildFile)
            {
                if (item.Name == "新建文件夹(" + n + ")")
                {
                    n++;
                }
            }
            //CreateDirectory用于创建新的文件夹，后面是拼接的文件路径
            Directory.CreateDirectory(node.Tag.ToString() + "\\" + "新建文件夹(" + n + ")");
            updatalist();
        }
        //新建文件
        private void tsmiText_Click(object sender, EventArgs e)
        {
            //获取tvDrive控件上的节点
            TreeNode node = this.tvDrive.SelectedNode;
            //节点标签赋值给name
            string name = node.Tag.ToString();
            //实例化一个新的目录（对应name名称），相当于节点C盘D盘
            DirectoryInfo file = new DirectoryInfo(name);
            //获得file目录下的所有子集合
            FileInfo[] ChildFi = file.GetFiles();
            int n = 1;
            foreach (FileInfo item in ChildFi)
            {
                if (item.Name == "新建文件夹(" + n + ")")
                {
                    n++;
                }
            }
            //CreateDirectory用于创建新的文件夹，后面是拼接的文件路径
            File.Create(node.Tag.ToString() + "\\" + "新建文件夹(" + n + ")"+"txt");
            updatalist();
        }
        //打开控件contextMenuStrip1的状态
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {   
            //判断，如果没有文件夹或者文件，基数=0
            if (this.lvFileList.SelectedItems.Count == 0)
            {

                // 只显示新建文件夹控件
                tsmiCopy.Visible = false;             
                tsmiShear.Visible = false;
                tsmiDelect.Visible = false;
                tsmiRename.Visible = false;
                tsmiNew.Visible = true;  
            }              
            else
            {
                //否则除了新建文件夹控件，其他的控件都显示
                tsmiCopy.Visible = true;           
                tsmiShear.Visible = true;
                tsmiDelect.Visible = true;
                tsmiRename.Visible = true;
                tsmiNew.Visible = false;          
            }

            //判断源路径是否存在  ,sourcePath定义时赋予空间，防止报错。
            if (sourcePath.Length <=0)
            {
                //源路径不存在则不启动粘贴控件
                tsmiPaste.Enabled = false;
            }
            else
            {
                //源路径存在则启动粘贴控件
                tsmiPaste.Enabled = true;
            }
        }

        //关闭窗体时，最后的操作记录记载到xml文件里
        private void From1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //创建XML文件
            XmlDocument xml = new XmlDocument();
            xml.AppendChild(xml.CreateXmlDeclaration("1.0", "UTF-8", null));//防止XML文件乱码
            //创建根节点Node
            XmlElement Node = xml.CreateElement("Node");
            //添加根节点Node到xml文件里
            xml.AppendChild(Node);
            //创建子节点record
            XmlElement record = xml.CreateElement("record");
            //获取子节点的串联值,==找到treeview控件选中的位置名称
            record.InnerText = this.tvDrive.SelectedNode.Tag.ToString();
            //添加子节点record到xml文件里
            Node.AppendChild(record);
            xml.Save("资源管理器\\ClosedKeep.xml");
        }

      
    }
}

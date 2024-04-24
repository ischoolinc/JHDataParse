using FISCA.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA;
using FISCA.Presentation;
using DevComponents.DotNetBar;
using JHDataParse.UIForm;

namespace JHDataParse
{
    public class Program
    {
        [FISCA.MainMethod()]
        public static void main()
        {
            Catalog ribbons1 = RoleAclSource.Instance["學生"]["功能按鈕"];
            ribbons1.Add(new RibbonFeature("DB02A577-579C-4CB7-AA06-67B3CD327D16", "刪除「學期」科目成績"));
            
            K12.Presentation.NLDPanels.Student.ListPaneContexMenu["刪除「學期」科目成績"].Image = Properties.Resources.exam_close_64;
            K12.Presentation.NLDPanels.Student.ListPaneContexMenu["刪除「學期」科目成績"].Enable = FISCA.Permission.UserAcl.Current["DB02A577-579C-4CB7-AA06-67B3CD327D16"].Executable;
            K12.Presentation.NLDPanels.Student.ListPaneContexMenu["刪除「學期」科目成績"].Click += delegate {
                if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0)
                {
                    frmDeleteSHSemsSubjectScore ss = new frmDeleteSHSemsSubjectScore();
                    ss.SetStudentIDs(K12.Presentation.NLDPanels.Student.SelectedSource);
                    ss.ShowDialog();
                }
            };

           
        }
    }
}

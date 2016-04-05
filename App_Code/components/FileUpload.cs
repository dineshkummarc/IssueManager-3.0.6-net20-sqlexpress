//Upload Control @0-AC7C2AA1
//Target Framework version is 2.0
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Collections.Specialized;
using System.Web.UI.HtmlControls;
using System.Security.Permissions;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace IssueManager.Controls
{
    public class FileUploadControl:WebControl,INamingContainer
    {
        protected enum FileAllocation{InputControl,TemporaryFolder,FileFolder,None}
        protected System.Web.UI.WebControls.CheckBox delControl = new System.Web.UI.WebControls.CheckBox();
        protected System.Web.UI.WebControls.Label fileNameLabel = new System.Web.UI.WebControls.Label();
        protected System.Web.UI.WebControls.Label fileSizeLabel = new System.Web.UI.WebControls.Label();
        protected System.Web.UI.LiteralControl literal1 = new System.Web.UI.LiteralControl("&nbsp;");
        protected System.Web.UI.LiteralControl literal2 = new System.Web.UI.LiteralControl("&nbsp;");
        protected System.Web.UI.WebControls.Label delLabel = new System.Web.UI.WebControls.Label();
        protected HtmlInputFile file =new HtmlInputFile();

        #region Properties

        public string AllowedFileMasks
        {
            get
            {
                if(ViewState["_allowedMasks"] == null)
                    return "*";
                else
                    return ViewState["_allowedMasks"] as string;
            }
            set
            {
                if(value == "" || value == null)
                    ViewState["_allowedMasks"] = "*";
                else
                    ViewState["_allowedMasks"] = value;
            }
        }

        public string DisallowedFileMasks
        {
            get
            {
                if(ViewState["_disallowedMasks"] == null)
                    return "";
                else
                    return ViewState["_disallowedMasks"] as string;
            }
            set
            {
                ViewState["_disallowedMasks"] = value;
            }
        }

        public string FileFolder
        {
            get
            {	
                if(ViewState["_fileFolder"] == null || (ViewState["_fileFolder"] as string) == "")
                    return MapPathSecure(TemplateSourceDirectory).TrimEnd(new char[]{'\\','/'});
                else
                    return (ViewState["_fileFolder"] as string).TrimEnd(new char[]{'\\','/'});
            }
            set
            {
                string path = value;
                if(!System.IO.Path.IsPathRooted(path)) path = MapPathSecure(path);
                if(!System.IO.Directory.Exists(path))
                    throw(new DirectoryNotFoundException("File folder is not found"));
                FileIOPermission fp = new FileIOPermission(FileIOPermissionAccess.Write, path);
                fp.Demand();
                ViewState["_fileFolder"] = path;
            }
        }

        public string TemporaryFolder
        {
            get
            {	
                if(ViewState["_temporaryFolder"] == null)
                    return "";
                else
                    return (ViewState["_temporaryFolder"] as string).TrimEnd(new char[]{'\\','/'});
            }
            set
            {
                if(value.StartsWith("%"))
                    ViewState["_temporaryFolder"] = Environment.GetEnvironmentVariable(value.TrimStart(new char[]{'%'}));
                else
                {
                    string path = value;
                    if(!System.IO.Path.IsPathRooted(path)) path = MapPathSecure(path);
                    ViewState["_temporaryFolder"] = path;
                }
                if(!System.IO.Directory.Exists(ViewState["_temporaryFolder"] as string))
                    throw(new DirectoryNotFoundException("Temporary folder is not found"));
                FileIOPermission fp = new FileIOPermission(FileIOPermissionAccess.Write, ViewState["_temporaryFolder"] as string);
                fp.Demand();
            }
        }

        public Int64 FileSizeLimit
        {
            get
            {
                if(ViewState["_fileSizeLimit"] == null)
                    return -1;
                else
                    return (long)ViewState["_fileSizeLimit"];
            }
            set
            {
                ViewState["_fileSizeLimit"] = value;
            }
        }

        public bool Required
        {
            get
            {
                if(ViewState["_required"] == null)
                    return false;
                else
                    return (bool)ViewState["_required"];
            }
            set
            {
                ViewState["_required"] = value;
            }
        }

        public long FileSize
        {

            get
            {	
                if(FileAllocation.FileFolder == Allocation)
                {
                    return new FileInfo(FileFolder + "\\" + Text).Length;
                }
                if(FileAllocation.TemporaryFolder == Allocation)
                {
                    return new FileInfo(TemporaryFolder + "\\" + Text).Length;
                }
                else
                {
                    EnsureChildControls();
                    return file.PostedFile.ContentLength;
                }
            }
        }

        protected string OriginalFileName
        {
            get
            {	
                if(FileAllocation.FileFolder == Allocation)
                {
                    return Text.Remove(0, Text.IndexOf(".") + 1);
                }
                else
                {
                    return ViewState["originalFileName"] as String;
                }
            }
            set
            {
                ViewState["originalFileName"] = value;
            }
        }

        protected string FileName
        {
            get
            {
                if(Allocation == FileAllocation.InputControl)
                {
                    EnsureChildControls();
                    return file.PostedFile.FileName;
                }
                if(Allocation == FileAllocation.TemporaryFolder || Allocation == FileAllocation.FileFolder)
                {
                    return ViewState["fileName"] as String;
                }
                return "";
            }
            set
            {
                ViewState["fileName"] = value;
            }
        }

        protected bool IsFilePosted
        {	
            get
            {	
                return (Allocation != FileAllocation.None);
            }
        }

        protected FileAllocation Allocation
        {
            get
            {	
                if(ViewState["allocation"]!=null)
                    return (FileAllocation)ViewState["allocation"];
                else
                {
                    ViewState["allocation"] = FileAllocation.None;
                    return FileAllocation.None;
                }
            }
            set
            {
                ViewState["allocation"] = value;
            }
        }

        public string Text
        {	
            get
            {	
                if(ViewState["_value"] == null)
                    return "";
                else
                    return ViewState["_value"] as string;
            }
            set
            {
                if(value!=null && value!="" && Allocation == FileAllocation.None && !System.IO.File.Exists(FileFolder + "\\" + value))
                    throw(new FileNotFoundException("FileNotFound"));
                ViewState["_value"] = value;
            }
        }

        public string Caption
        {	
            get
            {	
                if(ViewState["_caption"] == null)
                    return "";
                else
                    return ViewState["_caption"] as string;
            }
            set
            {
                ViewState["_caption"] = value;
            }
        }

        public string DeleteCaption
        {	
            get
            {	
                if(ViewState["_deleteCaption"] == null)
                    return "";
                else
                    return ViewState["_deleteCaption"] as string;
            }
            set
            {
                ViewState["_deleteCaption"] = value;
            }
        }

        #endregion 
        #region Events
        public event EventHandler BeforeProcessFile;
        public event EventHandler AfterProcessFile;
        public event EventHandler BeforeDeleteFile;
        public event EventHandler AfterDeleteFile;
        protected virtual void OnBeforeProcessFile(EventArgs e)
        {
            if (BeforeProcessFile != null)
                BeforeProcessFile(this, e);
        }
        protected virtual void OnAfterProcessFile(EventArgs e)
        {
            if (AfterProcessFile != null)
                AfterProcessFile(this, e);
        }
        protected virtual void OnBeforeDeleteFile(EventArgs e)
        {
            if (BeforeDeleteFile != null)
                BeforeDeleteFile(this, e);
        }
        protected virtual void OnAfterDeleteFile(EventArgs e)
        {
            if (AfterDeleteFile != null)
                AfterDeleteFile(this, e);
        }
        #endregion
        protected override void CreateChildControls() 
        {
            if(Text != "" && Allocation == FileAllocation.None)
            {
                if(System.IO.File.Exists(FileFolder + "\\" + Text))
                {
                    Allocation = FileAllocation.FileFolder;
                    FileName = Text;
                    ViewState["_oldFileName"] = Text;
                }
                else
                    throw(new FileNotFoundException(String.Format(Resources.strings.CCS_FileNotFound,ID,Text),Text));
            }
            delControl.ID = "delControl";
            delLabel.ID = "delLabel";
            delLabel.Text = DeleteCaption;
            fileNameLabel.ID = "fileName";
            fileSizeLabel.ID = "fileSize";
            file.ID = "file";

            Controls.Add(fileNameLabel);
            Controls.Add(literal1);
            Controls.Add(fileSizeLabel);
            Controls.Add(literal2);
            Controls.Add(delLabel);
            Controls.Add(delControl);
            Controls.Add(file);
        }

        private bool CompareByMask(string value, string mask)
        {
            if(mask=="*") return true;
            mask = (new Regex(@"([\.\$\^\{\[\(\|\)\+\\])").Replace(mask,@"\$1"));
            mask = (new Regex(@"\?").Replace(mask,@"[^\.]"));
            mask = (new Regex(@"\*").Replace(mask,@"[^\.]*"));
            mask = "^" + mask + "$";
            return new Regex(mask,RegexOptions.IgnoreCase).IsMatch(value);
        }

        private void CheckConstraints()
        {
            string fileName = Path.GetFileName(FileName);
            if(AllowedFileMasks!="*")
            {
                string[] masks = AllowedFileMasks.Split(new char[]{';'});
                bool result = false;
                for(int i=0;i < masks.Length;i++)
                    result=CompareByMask(fileName,masks[i]) || result;
                if(!result){
                    Allocation = FileAllocation.None;
                    throw(new InvalidOperationException("The file type is not allowed."));}
            }
            if(DisallowedFileMasks!="")
            {
                string[] masks = DisallowedFileMasks.Split(new char[]{';'});
                bool result = false;
                for(int i=0;i < masks.Length;i++)
                    result=CompareByMask(fileName,masks[i]) || result;
                if(result){
                    Allocation = FileAllocation.None;
                    throw(new InvalidOperationException("The file type is not allowed."));}
            }
            if(FileSizeLimit!=-1)
            {
                if(file.PostedFile.ContentLength > FileSizeLimit){
                    Allocation = FileAllocation.None;
                    throw(new InvalidOperationException("The file is too large."));}
            }
            return;
        }

        protected bool ProcessFile(int mode, string fileName)
        {
                switch(mode)
                {
                    case 1:
                        file.PostedFile.SaveAs(fileName);
                        Allocation = FileAllocation.TemporaryFolder;
                        Text = FileName;
                        break;
                    case 2:
                        OnBeforeProcessFile(EventArgs.Empty);
                        System.IO.File.Move(TemporaryFolder + "\\" + FileName,FileFolder + "\\" + FileName);
                        Allocation = FileAllocation.FileFolder;
                        Text = FileName;
                        if(ViewState["_oldFileName"] != null)
                            System.IO.File.Delete(FileFolder + "\\" + ViewState["_oldFileName"] as string);
                        OnAfterProcessFile(EventArgs.Empty);
                        break;
                    case 3:
                        OnBeforeDeleteFile(EventArgs.Empty);
                        if(Allocation == FileAllocation.TemporaryFolder)
                        {
                            System.IO.File.Delete(TemporaryFolder + "\\" + FileName);
                            Allocation = FileAllocation.None;
                            Text="";
                        }
                        if(Allocation == FileAllocation.FileFolder)
                        {
                            System.IO.File.Delete(FileFolder + "\\" + FileName);
                            Allocation = FileAllocation.None;
                            Text="";
                        }
                        OnAfterDeleteFile(EventArgs.Empty);
                        break;
                }
            return true;
        }

        public bool DeleteFile()
        {
            return ProcessFile(3, "");
        }

        public bool ValidateFile()
        {
            EnsureChildControls();
            if(delControl.Checked)
            {
                DeleteFile();
                delControl.Checked = false;
            }
            if((file.PostedFile == null || FileSize == 0)&& 
                Allocation != FileAllocation.FileFolder && Allocation != FileAllocation.TemporaryFolder)
            {
                Allocation = FileAllocation.None;
                return false;
            }
            else if(file.PostedFile != null && file.PostedFile.ContentLength != 0)
            {
                if(Allocation == FileAllocation.TemporaryFolder)
                    ProcessFile(3, "");
                Allocation = FileAllocation.InputControl;
                CheckConstraints();
                string fileName = Path.GetFileName(FileName);
                OriginalFileName = fileName;
                string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                int i = 1;
                string index = "";
                while(System.IO.File.Exists(TemporaryFolder + "\\" + timeStamp + index + "." + fileName ))
                {
                    index = i.ToString();
                    i++;
                }
                FileName = timeStamp + index + "." + fileName;
                fileName = TemporaryFolder + "\\" + timeStamp + index + "." + fileName;
                return ProcessFile(1, fileName);
            }
            return true;
        }

        public bool SaveFile()
        {
            EnsureChildControls();
            if(delControl.Checked)
            {
                DeleteFile();
                delControl.Checked = false;
            }
            if(Allocation == FileAllocation.InputControl)
                ValidateFile();
            if(Allocation == FileAllocation.TemporaryFolder)
                return ProcessFile(2, "");
            return true;
        }

        protected override void OnPreRender(EventArgs e)
        {

            if(CssClass!=""){
                file.Attributes.Add("class",CssClass);
                delControl.Attributes.Add("class",CssClass);}
            ControlStyle.Reset();

            foreach(Control c in Page.Controls)
                if(c is HtmlForm)
                {
                    ((HtmlForm)c).Enctype = "multipart/form-data";
                    break;
                }
            if(IsFilePosted && !Required){
                fileNameLabel.Text = OriginalFileName; 
                fileSizeLabel.Text = FileSize.ToString(); 
                file.Visible = false;
                delControl.Visible = true;
                delLabel.Visible = true;
                fileNameLabel.Visible = true;
                fileSizeLabel.Visible = true;
                literal1.Visible = true;
                literal2.Visible = true;
            }
            else if(IsFilePosted && Required){
                fileNameLabel.Text = OriginalFileName; 
                fileSizeLabel.Text = FileSize.ToString(); 
                file.Visible = true;
                delControl.Visible = false;
                delLabel.Visible = false;
                fileNameLabel.Visible = true;
                fileSizeLabel.Visible = true;
                literal1.Visible = true;
                literal2.Visible = true;
            }
            else
            {
                delControl.Visible = false;
                delLabel.Visible = false;
                fileNameLabel.Visible = false;
                fileSizeLabel.Visible = false;
                file.Visible = true;
                literal1.Visible = false;
                literal2.Visible = false;
            }

        }
    }
}
//End Upload Control


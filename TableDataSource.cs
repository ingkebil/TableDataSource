using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TableDataSource
{
    public class TableDataSource<T>: ObjectDataSource where T: DataTable
    {
        public T dt { get; set; }

        #region constructors
        public TableDataSource(UserControl parent, CompositeDataBoundControl boundcontrol)
            : base(typeof(TableDataSource<T>).GetType().AssemblyQualifiedName, "GetTable")
        {
            TypeName = this.GetType().AssemblyQualifiedName;
            this.ID = String.Concat(parent.ID, "SortableDataTable1");
            parent.Controls.Add(this);
            boundcontrol.DataSourceID = this.ID;
            parent.Page.RegisterRequiresControlState(this);
        }

        public TableDataSource(UserControl parent, CompositeDataBoundControl boundcontrol, T dt)
            : this(parent, boundcontrol)
        {
            this.dt = dt;
        }

        public TableDataSource()
            : base(typeof(TableDataSource<T>).GetType().AssemblyQualifiedName, "GetTable")
        {
            TypeName = this.GetType().AssemblyQualifiedName;
            if (dt == null)
            {
                dt = new DataTable() as T;
            }
        }
        #endregion constructors

        // adds the datatable to the objectdatasource
        void ods_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters.Add("dt", dt);
        }

        void ods_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            // maybe handle the exceptions here ...
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Selecting += ods_Selecting;
            this.Selected += ods_Selected;
        }

        protected override void OnUnload(EventArgs e)
        {
            this.Selecting -= ods_Selecting;
            this.Selected -= ods_Selected;
            base.OnUnload(e);
        }

        #region control state
        protected override object SaveControlState()
        {
            return new object[2] { base.SaveControlState(), dt};
        }

        protected override void LoadControlState(object savedState)
        {
            object[] objectarray = (object[])savedState;
            base.LoadControlState(objectarray[0]);
            this.dt = objectarray[1] as T;
        }
        #endregion control state

        public T GetTable(DataTable dt)
        {
            return dt as T;
        }

        public T GetTable()
        {
            return dt;
        }
    }
}

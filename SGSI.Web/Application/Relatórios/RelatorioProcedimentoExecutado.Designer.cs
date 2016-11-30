namespace SGSI.Web.Application.Relatórios
{
    partial class RelatorioProcedimentoExecutado
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioProcedimentoExecutado));
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.list1 = new Telerik.Reporting.List();
            this.panel1 = new Telerik.Reporting.Panel();
            this.txtProductNameLabel = new Telerik.Reporting.TextBox();
            this.txtYearLabel = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.shape1 = new Telerik.Reporting.Shape();
            this.shape2 = new Telerik.Reporting.Shape();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.shape3 = new Telerik.Reporting.Shape();
            this.pictureBox2 = new Telerik.Reporting.PictureBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.shape4 = new Telerik.Reporting.Shape();
            this.shape5 = new Telerik.Reporting.Shape();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Tcc1";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@p_procedimentoId", System.Data.DbType.Int32, "17")});
            this.sqlDataSource1.SelectCommand = "dbo.CarregaRelatorioEvidencia";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(9.6456689834594727D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.list1});
            this.detail.Name = "detail";
            // 
            // list1
            // 
            this.list1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(19.502922058105469D)));
            this.list1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(9.6456689834594727D)));
            this.list1.Body.SetCellContent(0, 0, this.panel1);
            tableGroup1.Name = "ColumnGroup1";
            this.list1.ColumnGroups.Add(tableGroup1);
            this.list1.DataSource = this.sqlDataSource1;
            this.list1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.list1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010002215276472271D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.list1.Name = "list1";
            tableGroup3.Name = "Group1";
            tableGroup2.ChildGroups.Add(tableGroup3);
            tableGroup2.Groupings.Add(new Telerik.Reporting.Grouping(""));
            tableGroup2.Name = "RowGroup1";
            this.list1.RowGroups.Add(tableGroup2);
            this.list1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.502922058105469D), Telerik.Reporting.Drawing.Unit.Inch(9.6456689834594727D));
            // 
            // panel1
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("=RowNumber() % 2", Telerik.Reporting.FilterOperator.Equal, "=0"));
            formattingRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(203)))));
            this.panel1.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtProductNameLabel,
            this.txtYearLabel,
            this.textBox3,
            this.textBox1,
            this.textBox2,
            this.textBox4,
            this.pictureBox1,
            this.textBox6,
            this.shape1,
            this.shape2,
            this.textBox11,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox12,
            this.textBox9,
            this.textBox10,
            this.textBox5,
            this.shape3,
            this.pictureBox2,
            this.textBox18,
            this.shape4,
            this.shape5,
            this.textBox7,
            this.textBox16,
            this.textBox17});
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.502922058105469D), Telerik.Reporting.Drawing.Unit.Inch(9.6456689834594727D));
            this.panel1.Style.BackgroundColor = System.Drawing.Color.White;
            this.panel1.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.panel1.Style.BorderColor.Default = System.Drawing.Color.White;
            this.panel1.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.panel1.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.panel1.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.panel1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel1.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel1.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.panel1.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.panel1.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.panel1.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            // 
            // txtProductNameLabel
            // 
            this.txtProductNameLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6928739547729492D), Telerik.Reporting.Drawing.Unit.Inch(1.4173227548599243D));
            this.txtProductNameLabel.Name = "txtProductNameLabel";
            this.txtProductNameLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4534546136856079D), Telerik.Reporting.Drawing.Unit.Inch(0.23622052371501923D));
            this.txtProductNameLabel.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.txtProductNameLabel.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.txtProductNameLabel.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.txtProductNameLabel.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.txtProductNameLabel.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.txtProductNameLabel.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.txtProductNameLabel.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.txtProductNameLabel.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.txtProductNameLabel.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.txtProductNameLabel.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.txtProductNameLabel.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.txtProductNameLabel.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.txtProductNameLabel.Style.Font.Bold = true;
            this.txtProductNameLabel.Style.Font.Name = "Segoe UI Light";
            this.txtProductNameLabel.Value = "Procedimento Id:";
            // 
            // txtYearLabel
            // 
            this.txtYearLabel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.0107301174430177E-05D), Telerik.Reporting.Drawing.Unit.Inch(5.2069664001464844D));
            this.txtYearLabel.Name = "txtYearLabel";
            this.txtYearLabel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.98417240381240845D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.txtYearLabel.Style.Font.Bold = true;
            this.txtYearLabel.Style.Font.Name = "Segoe UI Light";
            this.txtYearLabel.Value = "Descrição:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.9998998641967773D), Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.9694919586181641D), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269D));
            this.textBox3.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox3.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox3.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox3.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox3.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox3.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox3.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox3.Value = "= Fields.ProcedimentoId";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.0107301174430177E-05D), Telerik.Reporting.Drawing.Unit.Inch(4.8687663078308105D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0379364490509033D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.textBox1.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox1.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox1.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox1.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox1.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox1.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox1.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "Segoe UI Light";
            this.textBox1.Value = "Executador:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.636660099029541D), Telerik.Reporting.Drawing.Unit.Cm(12.366664886474609D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.2632298469543457D), Telerik.Reporting.Drawing.Unit.Cm(0.63500010967254639D));
            this.textBox2.Value = "= Fields.Executador";
            // 
            // textBox4
            // 
            this.textBox4.Angle = 0D;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5000998973846436D), Telerik.Reporting.Drawing.Unit.Cm(13.22569465637207D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.099800109863281D), Telerik.Reporting.Drawing.Unit.Cm(2.900001049041748D));
            this.textBox4.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox4.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox4.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox4.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox4.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox4.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox4.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox4.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox4.Value = "= Fields.Descricao";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Bottom)));
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9381169080734253D), Telerik.Reporting.Drawing.Unit.Cm(16.600000381469727D));
            this.pictureBox1.MimeType = "";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.52755880355835D), Telerik.Reporting.Drawing.Unit.Inch(3.0442593097686768D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox1.Value = "=\"http://localhost:50333/Application\"+ Fields.caminho";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6928739547729492D), Telerik.Reporting.Drawing.Unit.Inch(1.7716535329818726D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0236221551895142D), Telerik.Reporting.Drawing.Unit.Inch(0.23622052371501923D));
            this.textBox6.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox6.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox6.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox6.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox6.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox6.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox6.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox6.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox6.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox6.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox6.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox6.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Name = "Segoe UI Light";
            this.textBox6.Value = "Solicitante:";
            // 
            // shape1
            // 
            this.shape1.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Inch(4.1994752883911133D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.462448120117188D), Telerik.Reporting.Drawing.Unit.Point(3.75D));
            this.shape1.Stretch = true;
            this.shape1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.shape1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.shape1.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(3D);
            this.shape1.Style.Color = System.Drawing.Color.Transparent;
            // 
            // shape2
            // 
            this.shape2.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.shape2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010183890117332339D), Telerik.Reporting.Drawing.Unit.Inch(4.6985335350036621D));
            this.shape2.Name = "shape2";
            this.shape2.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.462347030639648D), Telerik.Reporting.Drawing.Unit.Point(3.75D));
            this.shape2.Stretch = true;
            this.shape2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.shape2.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.shape2.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(3D);
            this.shape2.Style.Color = System.Drawing.Color.Transparent;
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.9203777313232422D), Telerik.Reporting.Drawing.Unit.Cm(4.4999995231628418D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.977717399597168D), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269D));
            this.textBox11.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox11.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox11.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox11.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox11.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox11.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox11.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox11.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox11.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox11.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox11.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox11.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox11.Value = "= Fields.Solicitante";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6928739547729492D), Telerik.Reporting.Drawing.Unit.Inch(1.0629920959472656D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4534546136856079D), Telerik.Reporting.Drawing.Unit.Inch(0.23622052371501923D));
            this.textBox13.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox13.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox13.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox13.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox13.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox13.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox13.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox13.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Name = "Segoe UI Light";
            this.textBox13.Value = "Data Solicitação:";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.700100302696228D), Telerik.Reporting.Drawing.Unit.Cm(7.3999996185302734D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.03635835647583D), Telerik.Reporting.Drawing.Unit.Cm(0.59999930858612061D));
            this.textBox14.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox14.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox14.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox14.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox14.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox14.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox14.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox14.Value = "= Fields.Norma";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.0094058931572363E-05D), Telerik.Reporting.Drawing.Unit.Inch(2.9133856296539307D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.66921192407608032D), Telerik.Reporting.Drawing.Unit.Inch(0.23622052371501923D));
            this.textBox15.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox15.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox15.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox15.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox15.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox15.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox15.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox15.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Font.Name = "Segoe UI Light";
            this.textBox15.Value = "Norma:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.9998998641967773D), Telerik.Reporting.Drawing.Unit.Cm(2.6999998092651367D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.9363584518432617D), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269D));
            this.textBox12.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox12.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox12.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox12.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox12.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox12.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox12.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox12.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox12.Value = "= Fields.DataSolicitacao";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.9999604225158691D), Telerik.Reporting.Drawing.Unit.Inch(0.59055113792419434D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.76115506887435913D), Telerik.Reporting.Drawing.Unit.Inch(0.25000014901161194D));
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Font.Name = "Segoe UI Light";
            this.textBox9.Value = "Emissão:";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.636457443237305D), Telerik.Reporting.Drawing.Unit.Cm(1.4999998807907105D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8664646148681641D), Telerik.Reporting.Drawing.Unit.Cm(0.63499981164932251D));
            this.textBox10.Style.Font.Name = "Segoe UI Light";
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(13D);
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "= Now()";
            // 
            // textBox5
            // 
            this.textBox5.Angle = 0D;
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.462448120117188D), Telerik.Reporting.Drawing.Unit.Cm(1.3998997211456299D));
            this.textBox5.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(146)))), ((int)(((byte)(196)))));
            this.textBox5.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox5.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox5.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox5.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox5.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox5.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox5.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox5.Style.Color = System.Drawing.Color.Gold;
            this.textBox5.Style.Font.Bold = false;
            this.textBox5.Style.Font.Name = "Candara";
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(30D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "Relatório de procedimento";
            // 
            // shape3
            // 
            this.shape3.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.shape3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Inch(2.2835826873779297D));
            this.shape3.Name = "shape3";
            this.shape3.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.462448120117188D), Telerik.Reporting.Drawing.Unit.Point(3.75D));
            this.shape3.Stretch = true;
            this.shape3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.shape3.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.shape3.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.shape3.Style.Color = System.Drawing.Color.Transparent;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.4000000953674316D));
            this.pictureBox2.MimeType = "image/png";
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.2697935104370117D), Telerik.Reporting.Drawing.Unit.Cm(4.3999996185302734D));
            this.pictureBox2.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.pictureBox2.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.pictureBox2.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.pictureBox2.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.pictureBox2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureBox2.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureBox2.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureBox2.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureBox2.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.pictureBox2.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.pictureBox2.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.pictureBox2.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.pictureBox2.Value = ((object)(resources.GetObject("pictureBox2.Value")));
            // 
            // textBox18
            // 
            this.textBox18.Angle = 0D;
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010183890117332339D), Telerik.Reporting.Drawing.Unit.Cm(10.799159049987793D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.462347030639648D), Telerik.Reporting.Drawing.Unit.Cm(1.1349159479141235D));
            this.textBox18.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(146)))), ((int)(((byte)(196)))));
            this.textBox18.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox18.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox18.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox18.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox18.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox18.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox18.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox18.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox18.Style.Color = System.Drawing.Color.Gold;
            this.textBox18.Style.Font.Bold = false;
            this.textBox18.Style.Font.Name = "Candara";
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(30D);
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.Value = "Evidencia";
            // 
            // shape4
            // 
            this.shape4.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.shape4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.2998995780944824D), Telerik.Reporting.Drawing.Unit.Inch(0.919370174407959D));
            this.shape4.Name = "shape4";
            this.shape4.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.162548065185547D), Telerik.Reporting.Drawing.Unit.Point(3.75D));
            this.shape4.Stretch = true;
            this.shape4.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.shape4.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.shape4.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.shape4.Style.Color = System.Drawing.Color.Transparent;
            // 
            // shape5
            // 
            this.shape5.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.shape5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Inch(2.7836616039276123D));
            this.shape5.Name = "shape5";
            this.shape5.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.462448120117188D), Telerik.Reporting.Drawing.Unit.Point(3.75D));
            this.shape5.Stretch = true;
            this.shape5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.shape5.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.shape5.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(3D);
            this.shape5.Style.Color = System.Drawing.Color.Transparent;
            // 
            // textBox7
            // 
            this.textBox7.Angle = 0D;
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(5.9327917098999023D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.462448120117188D), Telerik.Reporting.Drawing.Unit.Cm(1.1349159479141235D));
            this.textBox7.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(146)))), ((int)(((byte)(196)))));
            this.textBox7.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox7.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox7.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox7.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox7.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox7.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox7.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox7.Style.Color = System.Drawing.Color.Gold;
            this.textBox7.Style.Font.Bold = false;
            this.textBox7.Style.Font.Name = "Candara";
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(30D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "Solicitação";
            // 
            // textBox16
            // 
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.3535106182098389D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.98421245813369751D), Telerik.Reporting.Drawing.Unit.Inch(0.23622052371501923D));
            this.textBox16.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox16.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox16.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox16.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox16.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox16.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox16.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox16.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox16.Style.Font.Bold = true;
            this.textBox16.Style.Font.Name = "Segoe UI Light";
            this.textBox16.Value = "Solicitação:";
            // 
            // textBox17
            // 
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5001001358032227D), Telerik.Reporting.Drawing.Unit.Cm(8.5179166793823242D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.099800109863281D), Telerik.Reporting.Drawing.Unit.Cm(1.8820837736129761D));
            this.textBox17.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.textBox17.Style.BorderColor.Left = System.Drawing.Color.Black;
            this.textBox17.Style.BorderColor.Right = System.Drawing.Color.Black;
            this.textBox17.Style.BorderColor.Top = System.Drawing.Color.Black;
            this.textBox17.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox17.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox17.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox17.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox17.Value = "= Fields.Solicitacao";
            // 
            // RelatorioProcedimentoExecutado
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "ListBoundReport";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.Font.Name = "Arial";
            this.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Header")});
            styleRule2.Style.Font.Bold = true;
            styleRule2.Style.Font.Name = "Segoe UI Light";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(25D);
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule3.Style.Font.Name = "Segoe UI Light";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(13D);
            styleRule3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule3.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.6783556938171387D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        
        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.List list1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox txtProductNameLabel;
        private Telerik.Reporting.TextBox txtYearLabel;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.Shape shape1;
        private Telerik.Reporting.Shape shape2;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.Shape shape3;
        private Telerik.Reporting.PictureBox pictureBox2;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.Shape shape4;
        private Telerik.Reporting.Shape shape5;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox17;
    }
}
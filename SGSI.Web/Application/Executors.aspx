<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Executors.aspx.cs" Inherits="SGSI.Web.Application.Executors" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=10.2.16.1025, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../JS/Telas.js" type="text/javascript"></script>
    <title>Executadores</title>
    <script>
        var resize = function (image, factor) {
            if (!factor || !image.complete) {
                return;
            }

            var orgSize = image.getOriginalSize();

            factor = parseFloat(factor);
            image.setSize(parseInt(orgSize.width * factor), parseInt(orgSize.height * factor));
        };
        var carrega = function (image, factor) {
            if (!factor || !image.complete) {
                return;
            }

            var orgSize = image.getOriginalSize();

            factor = parseFloat(factor);
            image.setSize(parseInt(orgSize.width * factor), parseInt(orgSize.height * factor));
        };
        var newFactor = function (combo, dir) {
            var index = combo.store.indexOf(combo.valueCollection.getAt(0)),
                count = combo.store.getCount();

            index += dir;

            if (index >= 0 && index < count) {
                combo.setValueAndFireSelect(combo.store.getAt(index).get(combo.valueField));
            }
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" DirectMethodNamespace="SGSI" Locale="pt-BR" Theme="Default" />

        <ext:Store ID="storeProcedimentos" runat="server" AutoLoad="true">
            <Model>
                <ext:Model runat="server" IDProperty="ProcedimentoId">
                    <Fields>
                        <ext:ModelField Name="Descricao" />
                        <ext:ModelField Name="Solicitante" />
                        <ext:ModelField Name="ProcedimentoId" />
                        <ext:ModelField Name="DepartamentoId" Type="Int" />
                        <ext:ModelField Name="Nome" />
                        <ext:ModelField Name="Norma" />
                        <ext:ModelField Name="DataInicial" Type="Date" />
                        <ext:ModelField Name="DataFinal" Type="Date" />
                        <ext:ModelField Name="Departamento" />
                        <ext:ModelField Name="ResponsavelAtual" />
                        <ext:ModelField Name="Cargo" />
                        <ext:ModelField Name="Situacao" />
                        <ext:ModelField Name="Progresso" />
                        <ext:ModelField Name="Caminho" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Store ID="storeHistoricoProc" runat="server" AutoLoad="true">
            <Model>
                <ext:Model runat="server" IDProperty="HistoricoId">
                    <Fields>
                        <ext:ModelField Name="HistoricoId" />
                        <ext:ModelField Name="ProcedimentoId" />
                        <ext:ModelField Name="Usuario" />
                        <ext:ModelField Name="DataHistorico" Type="Date" />
                        <ext:ModelField Name="Atualizacao" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Store ID="storeCarregaNormas" runat="server" AutoLoad="true">
            <Model>
                <ext:Model runat="server" IDProperty="Nome">
                    <Fields>
                        <ext:ModelField Name="NormaId" />
                        <ext:ModelField Name="Nome" />
                        <ext:ModelField Name="Caminho" />
                        <ext:ModelField Name="Criacao" Type="Date" />
                        <ext:ModelField Name="Autor" />
                        <ext:ModelField Name="Atualizacao" Type="Date" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Store ID="storeCmbNormas" runat="server" AutoLoad="true">
            <Model>
                <ext:Model runat="server" IDProperty="Nome">
                    <Fields>
                        <ext:ModelField Name="Nome" Type="String" />
                        <ext:ModelField Name="Caminho" Type="String" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Store ID="storeDepartamentos" runat="server" AutoLoad="true">
            <Model>
                <ext:Model runat="server" IDProperty="Id">
                    <Fields>
                        <ext:ModelField Name="Id" Type="Int" />
                        <ext:ModelField Name="Nome" Type="String" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Store ID="storeFuncionarios" runat="server" AutoLoad="true">
            <Model>
                <ext:Model runat="server" IDProperty="Nome">
                    <Fields>
                        <ext:ModelField Name="Nome" Type="String" />
                        <ext:ModelField Name="Email" Type="String" />
                        <ext:ModelField Name="Cargo" Type="String" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>

        <ext:Viewport runat="server" Layout="BorderLayout">
            <Items>
                <ext:TabPanel
                    ID="TabPanel1"
                    Region="Center"
                    runat="server"
                    TitleAlign="Right">
                    <TabBar>
                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                        <ext:Button ID="Button1" runat="server" Width="80" Flat="true" MarginSpec="0 10 0 0" Text="Sair" Icon="Disconnect">
                            <Listeners>
                                <Click Handler="Tcc.javaScript.ManagerExit();" />
                            </Listeners>
                        </ext:Button>
                    </TabBar>
                    <Items>
                        <%--DashBoard--%>
                        <ext:Panel runat="server" Title="Dashboard" Width="800"
                            Height="600" Layout="FitLayout" Padding="30">
                            <Items>
                                <ext:FormPanel runat="server" HeaderPosition="Right">
                                    <Defaults>
                                        <ext:Parameter Name="margin" Value="30 0 0 100" Mode="Value" />
                                    </Defaults>
                                    <Items>
                                        <ext:Panel runat="server" Width="800"
                                            Height="400" Layout="FitLayout">
                                            <Items>
                                                <ext:CartesianChart
                                                    ID="Chart1"
                                                    runat="server"
                                                    Title="Tecnologia da Informação">
                                                    <AnimationConfig Easing="BounceOut" Duration="750" />

                                                    <Gradients>
                                                        <ext:LinearGradient GradientID="v-1" Degrees="0">
                                                            <Stops>
                                                                <ext:GradientStop Offset="0" Color="rgb(212, 40, 40)" />
                                                                <ext:GradientStop Offset="100" Color="rgb(117, 14, 14)" />
                                                            </Stops>
                                                        </ext:LinearGradient>

                                                        <ext:LinearGradient GradientID="v-2" Degrees="0">
                                                            <Stops>
                                                                <ext:GradientStop Offset="0" Color="rgb(180, 216, 42)" />
                                                                <ext:GradientStop Offset="100" Color="rgb(94, 114, 13)" />
                                                            </Stops>
                                                        </ext:LinearGradient>

                                                        <ext:LinearGradient GradientID="v-3" Degrees="0">
                                                            <Stops>
                                                                <ext:GradientStop Offset="0" Color="rgb(43, 221, 115)" />
                                                                <ext:GradientStop Offset="100" Color="rgb(14, 117, 56)" />
                                                            </Stops>
                                                        </ext:LinearGradient>

                                                        <ext:LinearGradient GradientID="v-4" Degrees="0">
                                                            <Stops>
                                                                <ext:GradientStop Offset="0" Color="rgb(45, 117, 226)" />
                                                                <ext:GradientStop Offset="100" Color="rgb(14, 56, 117)" />
                                                            </Stops>
                                                        </ext:LinearGradient>

                                                        <ext:LinearGradient GradientID="v-5" Degrees="0">
                                                            <Stops>
                                                                <ext:GradientStop Offset="0" Color="rgb(187, 45, 222)" />
                                                                <ext:GradientStop Offset="100" Color="rgb(85, 10, 103)" />
                                                            </Stops>
                                                        </ext:LinearGradient>
                                                    </Gradients>

                                                    <Axes>
                                                        <ext:NumericAxis
                                                            Position="Left"
                                                            Fields="Data1"
                                                            Title="Number of Hits"
                                                            Minimum="0"
                                                            Maximum="100">
                                                            <Renderer Handler="return Ext.util.Format.number(label, '0,0');" />
                                                            <GridConfig>
                                                                <Odd StrokeStyle="#555" />
                                                                <Even StrokeStyle="#555" />
                                                            </GridConfig>
                                                        </ext:NumericAxis>
                                                        <ext:CategoryAxis Position="Bottom" Fields="Name" Title="Procedimentos" />
                                                    </Axes>
                                                    <Series>
                                                        <ext:BarSeries
                                                            Highlight="true"
                                                            XField="Name"
                                                            YField="10">
                                                            <Label
                                                                Display="InsideEnd"
                                                                Field="Data1"
                                                                Orientation="Horizontal"
                                                                FillStyle="#000"
                                                                Font="17px Arial"
                                                                TextAlign="Center">
                                                                <Renderer Handler="return Ext.util.Format.number(text, '0');" />
                                                            </Label>
                                                            <StyleSpec>
                                                                <ext:Sprite Opacity="0.95" />
                                                            </StyleSpec>
                                                            <Renderer Handler="var colors = ['url(#v-1)','url(#v-2)','url(#v-3)','url(#v-4)','url(#v-5)'];return {fill : colors[index % colors.length]};" />
                                                        </ext:BarSeries>
                                                    </Series>
                                                </ext:CartesianChart>
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:FormPanel>
                            </Items>
                        </ext:Panel>
                        <ext:Hidden runat="server" ID="HUserName" />

                        <%--###Tab de Procedimentos###--%>
                        <ext:Panel ID="TabProcedimentos"
                            runat="server"
                            Title="Procedimentos"
                            Icon="LayoutHeader">
                            <TabConfig runat="server">
                                <Plugins>
                                    <ext:Badge ID="NotificProc" runat="server" Scale="Small" />
                                </Plugins>
                            </TabConfig>
                            <LayoutConfig>
                                <ext:HBoxLayoutConfig Align="Stretch" />
                            </LayoutConfig>
                            <Items>
                                <ext:Container runat="server" ID="Container1" Layout="FitLayout" ResizeHandles="All" HeightSpec="100%" WidthSpec="100%" StyleSpec="Width:100%" MonitorResize="true" AnchorVertical="100%" AnchorHorizontal="100%" Region="Center">
                                    <Items>
                                        <ext:GridPanel
                                            ID="GridProcedimentos"
                                            RowLines="true"
                                            Title="Procedimentos Cadastrados"
                                            TitleAlign="Center"
                                            Header="true"
                                            TrackMouseOver="false"
                                            runat="server"
                                            TitleCollapse="false"
                                            Collapsible="false"
                                            AutoFill="false"
                                            MonitorResize="true"
                                            Stateful="true"
                                            EnableColumnHide="true"
                                            WidthSpec="100%"
                                            StoreID="storeProcedimentos">
                                            <ColumnModel>
                                                <Columns>
                                                    <ext:RowNumbererColumn runat="server" Width="30" />
                                                    <ext:Column ID="ColumnProcId" runat="server" Text="Id" Width="150" DataIndex="ProcedimentoId" Hidden="true" />
                                                    <ext:Column ID="ColumnDpId" runat="server" Text="DpId" Width="150" DataIndex="DepartamentoId" Hidden="true" />
                                                    <ext:Column ID="ColumnSolicitante" runat="server" Text="Solicitante" Width="150" DataIndex="Solicitante" Hidden="true" />
                                                    <ext:Column ID="ColumnDescricao" runat="server" Text="Descricao" Width="150" DataIndex="Descricao" Hidden="true" />
                                                    <ext:Column ID="ColumnNome" runat="server" Text="Nome" Width="150" DataIndex="Nome" />
                                                    <ext:Column ID="ColumnNorma" runat="server" Text="Norma" Width="150" DataIndex="Norma" />
                                                    <ext:DateColumn ID="ColumndtInicial" runat="server" Text="Data Inicial" DataIndex="DataInicial" Format="dd/MM/yyyy" />
                                                    <ext:DateColumn ID="ColumndtFInal" runat="server" Text="Data Final" DataIndex="DataFinal" Format="dd/MM/yyyy" />
                                                    <ext:Column ID="ColumnDepartamento" runat="server" Text="Departamento" Width="150" DataIndex="Departamento" Format="dd/MM/yyyy" />
                                                    <ext:Column ID="ColumnResponsalvel" runat="server" Text="Responsável atual" Width="150" DataIndex="ResponsavelAtual" />
                                                    <ext:Column ID="ColumnCargo" runat="server" Text="Cargo" Width="150" DataIndex="Cargo" />
                                                    <ext:Column ID="ColumnSituacao" runat="server" Text="Situacão" Width="150" DataIndex="Situacao" />
                                                    <ext:ProgressBarColumn ID="BarProgress" runat="server" Text="Progresso" Width="150" DataIndex="Progresso" />
                                                    <ext:Column ID="Column8" runat="server" Text="Situacão" Width="150" DataIndex="Caminho" Hidden="true" />
                                                    <ext:CommandColumn runat="server">
                                                        <Commands>
                                                            <ext:GridCommand ToolTip-Title="Detalhes" CommandName="Detalhes" Icon="ApplicationViewDetail" />
                                                            <ext:GridCommand ToolTip-Title="Aceitar" CommandName="Aceitar" Icon="Accept" Hidden="true" />
                                                            <ext:GridCommand ToolTip-Title="Aceitar" CommandName="AceitarNivel2" Icon="Accept" Hidden="true" />
                                                            <ext:GridCommand ToolTip-Title="Recusar" CommandName="Recusar" Icon="Cancel" Hidden="true" />
                                                            <ext:GridCommand ToolTip-Title="Delegar" CommandName="Delegar" Icon="UserGo" Hidden="true" />
                                                            <ext:GridCommand ToolTip-Title="Executar" CommandName="Executar" Icon="PlayGreen" Hidden="true" />
                                                            <ext:GridCommand ToolTip-Title="Concluir Execução" CommandName="ConcluirExec" Icon="Tick" Hidden="true" />
                                                            <ext:GridCommand ToolTip-Title="Aprovar Procedimento" CommandName="AprovaProc" Icon="ApplicationGo" Hidden="true" />
                                                            <ext:GridCommand ToolTip-Title="Apagar" CommandName="Apagar" Icon="Delete" Hidden="true" />
                                                        </Commands>
                                                        <PrepareToolbar Fn="Tcc.javaScript.desabilitarCommand" />
                                                        <Listeners>
                                                            <Command Handler="Tcc.javaScript.gridProcedimentos(command, record, #{WinDetalhes}, #{FormDetalhes});" />
                                                        </Listeners>
                                                    </ext:CommandColumn>
                                                </Columns>

                                            </ColumnModel>
                                            <BottomBar>
                                                <ext:PagingToolbar ID="PagingToolbar3" runat="server" PageSize="2" />
                                            </BottomBar>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" Mode="Multi">
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <ViewConfig StripeRows="true">
                                            </ViewConfig>

                                        </ext:GridPanel>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Panel>
                        
                        <%--##Tab normas##--%>
                        <ext:Panel
                            ID="TabNormas"
                            runat="server"
                            Title="Normas"
                            Icon="Bookmark">
                            <DockedItems>
                                <ext:Toolbar runat="server" Dock="top" Width="50">
                                    <Items>
                                        <ext:Button ID="Button2" runat="server" Text="Nova norma" Icon="Add">
                                            <Listeners>
                                                <Click Handler="#{FormNorma}.reset(), #{WinNorma}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </DockedItems>
                            <LayoutConfig>
                                <ext:HBoxLayoutConfig Align="Stretch" />
                            </LayoutConfig>
                            <Items>
                                <ext:Container runat="server" ID="Container2" Layout="FitLayout" ResizeHandles="All" HeightSpec="100%" WidthSpec="100%" StyleSpec="Width:100%" MonitorResize="true" AnchorVertical="100%" AnchorHorizontal="100%" Region="Center">
                                    <Items>
                                        <ext:GridPanel
                                            ID="GridNormas"
                                            runat="server"
                                            RowLines="true"
                                            Title="Normas Cadastradas"
                                            TitleAlign="Center"
                                            TitleCollapse="false"
                                            Collapsible="false"
                                            AutoFill="false"
                                            MonitorResize="true"
                                            Stateful="true"
                                            EnableColumnHide="true"
                                            WidthSpec="100%"
                                            StoreID="storeCarregaNormas">
                                            <ColumnModel>
                                                <Columns>
                                                    <ext:RowNumbererColumn runat="server" Width="30" />
                                                    <ext:Column ID="ClnNormasNome" runat="server" Text="Nome" DataIndex="Nome" Width="150" />
                                                    <ext:Column runat="server" DataIndex="Caminho" Hidden="true" />
                                                    <ext:DateColumn ID="DateColumNormasCriac" runat="server" Format="dd/MM/yyyy HH:mm" Text="Data de Criação" DataIndex="Criacao" Width="200" />
                                                    <ext:Column ID="ClnNormasAutor" runat="server" Text="Autor" DataIndex="Autor" Width="170" />
                                                    <ext:DateColumn ID="DateColumNormasAtuali" runat="server" Format="dd/MM/yyyy HH:mm" Text="Data de Atualização" DataIndex="Atualizacao" Width="200" EmptyCellText="Não alterado" />
                                                    <ext:CommandColumn runat="server" Width="65" Text="Anexos">
                                                        <Commands>
                                                            <ext:GridCommand Icon="PageWhiteAcrobat" CommandName="Norma" ToolTip-Text="Ver Norma" />
                                                        </Commands>
                                                        <Listeners>
                                                            <Command Handler="Tcc.javaScript.gridNormas(command, record);" />
                                                        </Listeners>
                                                    </ext:CommandColumn>
                                                </Columns>
                                            </ColumnModel>
                                            <BottomBar>
                                                <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="2" />
                                            </BottomBar>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" Mode="Multi">
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <ViewConfig StripeRows="true">
                                            </ViewConfig>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel>



                <%--Janela de detalhes do procedimentos--%>
                <ext:Window runat="server" ID="WinDetalhes" Title="Detalhes procedimento" Closable="false" TitleAlign="Center" ButtonAlign="Center" AutoHeight="true" Padding="5" Hidden="true" Modal="true" Width="800px" Height="650px">
                    <Items>
                        <ext:FormPanel runat="server" ID="FormDetalhes" Border="false" Frame="true" BodyPadding="10" DefaultAnchor="100%">
                            <FieldDefaults
                                LabelAlign="Top"
                                LabelWidth="100"
                                LabelStyle="font-weight:bold;" />
                            <Defaults>
                                <ext:Parameter Name="margin" Value="0 0 10 0" Mode="Value" />
                            </Defaults>
                            <Items>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextField runat="server" ID="TextField2" Width="50" FieldLabel="Id" MarginSpec="0 0 0 10" Editable="false" DataIndex="ProcedimentoId" />
                                        <ext:TextField runat="server" ID="TextField1" Width="100" FieldLabel="Solicitante" MarginSpec="0 0 0 10" Editable="false" DataIndex="Solicitante" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:DateField runat="server" ID="DateField1" FieldLabel="Data Inicial" MarginSpec="0 0 0 10" Selectable="false" Format="dd/MM/yyyy" Editable="false" DataIndex="DataInicial" />
                                        <ext:DateField runat="server" ID="DateField2" FieldLabel="Data Final" MarginSpec="0 0 0 10" Selectable="false" Editable="false" Format="dd/MM/yyyy" DataIndex="DataFinal" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextArea runat="server" MarginSpec="0 20 0 10" Padding="10" FieldLabel="Descrição" ID="TextArea1" Width="450" MaxLengthText="250" Editable="false" DataIndex="Descricao" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextField runat="server" Hidden="true" ID="Caminhotxt" DataIndex="Caminho" />
                                        <ext:Button runat="server" Text="Abrir norma" MarginSpec="0 0 0 10" Icon="PageWhiteAcrobat">
                                            <Listeners>
                                                <Click Handler="Tcc.javaScript.abrirNorma(#{Caminhotxt}.getValue());" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:FieldContainer>
                            </Items>
                        </ext:FormPanel>
                        <ext:GridPanel
                            ID="GridHistoricoProcedimentos"
                            runat="server"
                            RowLines="true"
                            Title="Histórico do Procedimento"
                            TitleAlign="Center"
                            ColumnLines="true"
                            DefaultAnchor="100%"
                            Fixed="true"
                            StoreID="storeHistoricoProc">
                            <ColumnModel>
                                <Columns>
                                    <ext:RowNumbererColumn runat="server" Width="30" />
                                    <ext:Column ID="Column5" runat="server" Text="HistoricoId" DataIndex="HistoricoId" Width="150" Hidden="true" />
                                    <ext:Column runat="server" Text="ProcedimentoId" DataIndex="ProcedimentoId" />
                                    <ext:DateColumn ID="DateColumN1" runat="server" Format="dd/MM/yyyy HH:mm" Text="Data da Atualização" DataIndex="DataHistorico" Width="200" />
                                    <ext:Column ID="Column6" runat="server" Text="Usuario" DataIndex="Usuario" Width="170" />
                                    <ext:Column ID="Column7" runat="server" Text="Atualizacao" DataIndex="Atualizacao" Width="170" />
                                </Columns>
                            </ColumnModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar4" runat="server" PageSize="2" />
                            </BottomBar>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel4" runat="server" Mode="Multi">
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <ViewConfig StripeRows="true">
                            </ViewConfig>
                        </ext:GridPanel>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" Text="Fechar" Icon="Decline">
                            <Listeners>
                                <Click Handler="#{WinDetalhes}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>

                <%--Janela de Delegar--%>
                <ext:Window runat="server" ID="WindowDelegar" Title="Delegar Procedimento" Closable="false" TitleAlign="Center" AutoHeight="true" ButtonAlign="Center" Padding="5" Modal="true" Width="400px" Hidden="true">
                    <Items>
                        <ext:FormPanel runat="server" ID="FormDelegar" Border="false" Frame="true" BodyPadding="10" DefaultAnchor="100%">
                            <FieldDefaults
                                LabelAlign="Top"
                                LabelWidth="100"
                                LabelStyle="font-weight:bold;" />
                            <Defaults>
                                <ext:Parameter Name="margin" Value="0 0 10 0" Mode="Value" />
                            </Defaults>
                            <Items>
                                <ext:Hidden runat="server" ID="progressov" DataIndex="Progresso" />
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextField runat="server" ID="TextFieldProcedimentoId" Width="50" FieldLabel="Id" MarginSpec="0 0 0 10" Editable="false" DataIndex="ProcedimentoId" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:ComboBox runat="server" ID="CmbNewUserNome" MarginSpec="0 0 0 10" FieldLabel="Funcionario" Text="Selecione" Editable="false" AllowBlank="false" StoreID="storeFuncionarios" DataIndex="Nome" DisplayField="Nome" EmptyText="Carregando...">
                                            <Listeners>
                                                <Select Handler="Tcc.javaScript.carregarCargo(#{CmbNewUserNome}.getValue())" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextField runat="server" ID="TextNewUserEmail" FieldLabel="E-mail" Editable="false" MarginSpec="0 0 0 10" />
                                        <ext:TextField runat="server" ID="TextNewUserCargo" FieldLabel="Cargo" Editable="false" MarginSpec="0 0 0 10" />
                                    </Items>
                                </ext:FieldContainer>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" Text="Enviar" Icon="Accept">
                            <Listeners>
                                <Click Handler="if(#{FormDelegar}.isValid()) {Tcc.javaScript.enviarDelegar(#{CmbNewUserNome}.getValue(), #{TextFieldProcedimentoId}.getValue(), #{progressov}.getValue(), #{TextNewUserCargo}.getValue(), #{WindowDelegar})};" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Fechar" Icon="Decline">
                            <Listeners>
                                <Click Handler="#{WindowDelegar}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>

                <%--        <ext:Window runat="server" ID="Window1" Title="Delegar Procedimento" Closable="false" TitleAlign="Center" AutoHeight="true" ButtonAlign="Center" Padding="5" Modal="true" Width="400px" Hidden="true">
                    <Items>
                        <ext:FormPanel runat="server" ID="FormPanel1" Border="false" Frame="true" BodyPadding="10" DefaultAnchor="100%">
                            <FieldDefaults
                                LabelAlign="Top"
                                LabelWidth="100"
                                LabelStyle="font-weight:bold;" />
                            <Defaults>
                                <ext:Parameter Name="margin" Value="0 0 10 0" Mode="Value" />
                            </Defaults>
                            <Items>
                                <ext:Hidden runat="server" ID="Hidden1" DataIndex="Progresso" />
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextField runat="server" ID="TextField3" Width="50" FieldLabel="Id" MarginSpec="0 0 0 10" Editable="false" DataIndex="ProcedimentoId" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:ComboBox runat="server" ID="ComboBox1" MarginSpec="0 0 0 10" FieldLabel="Funcionario" Text="Selecione" Editable="false" AllowBlank="false" StoreID="storeFuncionarios" DataIndex="Nome" DisplayField="Nome" EmptyText="Carregando...">
                                            <Listeners>
                                                <Select Handler="Tcc.javaScript.carregarCargo(#{CmbNewUserNome}.getValue())" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextField runat="server" ID="TextField4" FieldLabel="E-mail" Editable="false" MarginSpec="0 0 0 10" />
                                        <ext:TextField runat="server" ID="TextField5" FieldLabel="Cargo" Editable="false" MarginSpec="0 0 0 10" />
                                    </Items>
                                </ext:FieldContainer>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" Text="Enviar" Icon="Accept">
                            <Listeners>
                                <Click Handler="if(#{FormDelegar}.isValid()) {Tcc.javaScript.enviarDelegar(#{CmbNewUserNome}.getValue(), #{TextFieldProcedimentoId}.getValue(), #{progressov}.getValue(), #{TextNewUserCargo}.getValue(), #{WindowDelegar})};" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Fechar" Icon="Decline">
                            <Listeners>
                                <Click Handler="#{WindowDelegar}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>--%>

                <%--Janela de Concluir Execução--%>
                <ext:Window runat="server" ID="WinConcProce" Hidden="true" Title="Concluir procedimento" Closable="false" TitleAlign="Center" Width="500" ButtonAlign="Center" AutoHeight="true" Padding="5" Modal="true">
                    <Items>
                        <ext:FormPanel runat="server" ID="FormConcProce" Frame="true" BodyPadding="10" DefaultAnchor="100%">
                            <FieldDefaults
                                LabelAlign="Top"
                                LabelWidth="100"
                                LabelStyle="font-weight:bold;" />
                            <Defaults>
                                <ext:Parameter Name="margin" Value="0 0 10 0" Mode="Value" />
                            </Defaults>
                            <Items>
                                    <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                         <ext:Hidden runat="server" ID="ConcProceProcProgresso" DataIndex="Progresso" />
                                        <ext:TextField runat="server" ID="ConcProceProcId" FieldLabel="Id" Width="50" DataIndex="ProcedimentoId" />
                                        <ext:TextField runat="server" ID="ConcProceDPId"  DataIndex="DepartamentoId" Hidden="true"/>
                                        <ext:TextField runat="server" ID="ConcProceSolicitanteId" FieldLabel="Solicitante" MarginSpec="0 0 0 5" DataIndex="Solicitante" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextArea runat="server" ID="TextAreaConcProce" FieldLabel="Descrição" Width="300" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:FileUploadField runat="server" ID="FileUploadEviden" FieldLabel="Evidência" ButtonText="Selecionar..." Icon="ImageAdd">
                                            <Listeners>
                                              
                                            </Listeners>
                                        </ext:FileUploadField>
                                    </Items>
                                </ext:FieldContainer>
                            </Items>
                        </ext:FormPanel>

                    </Items>
                    <Buttons>
                        <ext:Button runat="server" Text="Enviar" Icon="ScriptGo">
                            <Listeners>
                                <Click Handler="if(#{FormConcProce}.isValid()) {Tcc.javaScript.concluirProcedimento(#{ConcProceProcId}.getValue(), #{ConcProceDPId}.getValue(), #{ConcProceProcProgresso}.getValue(), #{WinConcProce}, #{TextAreaConcProce}.getValue())};" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Fechar" Icon="Decline">
                            <Listeners>
                                <Click Handler="#{WinConcProce}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>
                <ext:Window runat="server"  Width="950" ButtonAlign="Center" AutoHeight="true" Padding="5" Modal="true" >
                    <Content>
                        <telerik:ReportViewer ID="ReportViewer1"  runat="server" ParametersAreaVisible="true" Resources-ReportParametersFalseValueLabel="17" Width="100%" Height="700" >
                      <Resources>
                          
                      </Resources>
                        </telerik:ReportViewer>

                    </Content>
                </ext:Window>



            </Items>

        </ext:Viewport>
    </form>
</body>
</html>

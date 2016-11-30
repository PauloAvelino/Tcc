<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecurityOffice.aspx.cs" Inherits="SGSI.Web.Application.SecurityOffice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Security Office</title>
    <script src="../JS/Telas.js"></script>
    <link href="../Css/Css.css" rel="stylesheet" />
</head>
<body>
    <ext:ResourceManager ID="ResourceManager2" runat="server" DirectMethodNamespace="SGSI" Locale="pt-BR" />

    <form id="form1" runat="server">

        <ext:Store ID="storeUsuarios" runat="server" OnReadData="CarregaUsuarios" AutomaticResponseValues="true">
            <Model>
                <ext:Model runat="server" IDProperty="Nome">
                    <Fields>
                        <ext:ModelField Name="Nome" />
                        <ext:ModelField Name="Departamento" />
                        <ext:ModelField Name="Cargo" />
                        <ext:ModelField Name="Email" />
                        <ext:ModelField Name="Ativo" Type="Int" />
                    </Fields>
                </ext:Model>
            </Model>
            <Sorters>
                <ext:DataSorter Property="Ativo" Direction="DESC" />
            </Sorters>
        </ext:Store>
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
        <ext:Store ID="storeGrupoUsuarios" runat="server" AutoLoad="true">
            <Model>
                <ext:Model runat="server" IDProperty="AcessoId">
                    <Fields>
                        <ext:ModelField Name="AcessoId" Type="Int" />
                        <ext:ModelField Name="Descricao" Type="String" />
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
                        <ext:ModelField Name="Departamento" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Store ID="storeCarregaHistoricoNorma" runat="server" AutoLoad="true">
            <Model>
                <ext:Model runat="server" IDProperty="HistoricoNormaId">
                    <Fields>
                        <ext:ModelField Name="HistoricoNormaId" />
                        <ext:ModelField Name="Usuario" />
                        <ext:ModelField Name="Situacao" />
                        <ext:ModelField Name="DataAtualizacao" Type="Date" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:Hidden runat="server" ID="HUserName" />
        <ext:Viewport runat="server" Layout="FitLayout" Region="Center">

            <Items>
                <ext:TabPanel
                    ID="TabPanel1"
                    Region="Center"
                    runat="server"
                    TitleAlign="Right"
                    Padding="50"
                    PaddingSpec="40 40 40 40">
                    <TabBar>
                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                        <%--  <ext:Label ID="LabelEmail" runat="server" Icon="User" MarginSpec="10 10 10 10"  />--%>
                        <ext:Button ID="Button1" runat="server" Flat="true" Text="Sair" Icon="Disconnect">
                            <Listeners>
                                <Click Handler="Tcc.javaScript.logout();" />
                            </Listeners>
                        </ext:Button>
                    </TabBar>
                    <Items>
                        <%--###Tab de Procedimentos###--%>
                        <ext:Panel ID="TabProcedimentos"
                            runat="server"
                            Title="Procedimentos"
                            Icon="LayoutHeader"
                            Height="50">
                            <%--<DockedItems>
                                <ext:Toolbar runat="server" Dock="top" Width="50">
                                    <Items>
                                        <ext:ToolbarTextItem Text="Procedimentos Cadastrados" />
                                        <ext:Button ID="Button3" runat="server" Text="Novo Procedimento" Icon="Add">
                                            <Listeners>
                                                <Click Handler="#{FormProcedimentos}.reset(), #{WinProcedimentos}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </DockedItems>--%>
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
                                            <DockedItems>
                                                <ext:Toolbar runat="server" Dock="top" Width="50">
                                                    <Items>
                                                        <ext:Button ID="Button4" runat="server" Text="Novo Procedimento" Icon="Add">
                                                            <Listeners>
                                                                <Click Handler="#{FormProcedimentos}.reset(), #{WinProcedimentos}.show();" />
                                                            </Listeners>
                                                        </ext:Button>
                                                    </Items>
                                                </ext:Toolbar>
                                            </DockedItems>
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
                                                    <ext:Column ID="ColumnDepartamento" runat="server" Text="Departamento" Width="150" DataIndex="Departamento" />
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
                                            <ColumnModel>
                                                <Columns>
                                                    <ext:RowNumbererColumn runat="server" Width="30" />
                                                    <ext:Column ID="ClnNormasId" runat="server" Text="NormaId" DataIndex="NormaId" Width="150" Hidden="true" />
                                                    <ext:Column ID="ClnNormasNome" runat="server" Text="Nome" DataIndex="Nome" Width="150" />
                                                    <ext:Column ID="ClnNormasDepartamento" runat="server" Text="Departamento" DataIndex="Departamento" Width="200" />
                                                    <ext:Column runat="server" DataIndex="Caminho" Hidden="true" />
                                                    <ext:DateColumn ID="DateColumNormasCriac" runat="server" Format="dd/MM/yyyy HH:mm" Text="Data de Criação" DataIndex="Criacao" Width="200" />
                                                    <ext:Column ID="ClnNormasAutor" runat="server" Text="Autor" DataIndex="Autor" Width="170" />
                                                    <ext:DateColumn ID="DateColumNormasAtuali" runat="server" Format="dd/MM/yyyy HH:mm" Text="Data de Atualização" DataIndex="Atualizacao" Width="200" EmptyCellText="Não alterado" />
                                                    <ext:CommandColumn runat="server" Width="100">
                                                        <Commands>
                                                            <ext:GridCommand Icon="PageWhiteAcrobat" CommandName="Norma" ToolTip-Text="Abrir Norma" />
                                                            <ext:GridCommand Icon="PageWhiteEdit" CommandName="Atualizar" ToolTip-Text="Atualizar Norma" />
                                                            <ext:GridCommand Icon="Delete" CommandName="Apagar" ToolTip-Text="Apagar " />
                                                            <ext:GridCommand Icon="ApplicationViewDetail" CommandName="Historico" ToolTip-Text="Histórico " />
                                                        </Commands>
                                                        <Listeners>
                                                            <Command Handler="Tcc.javaScript.gridNormas(command, record, #{WindowAtualizarNorma}, #{FormAtualizarNorma}, #{WindowHistoricoNorma}, #{FormHistoricoNormas});" />
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

                        <%--###Tab de Auditoria###--%>
                        <ext:Panel ID="TabAuditoria"
                            runat="server"
                            Title="Auditoria"
                            Icon="Shield">

                            <LayoutConfig>
                                <ext:HBoxLayoutConfig Align="Stretch" />
                            </LayoutConfig>
                            <Items>
                                <ext:Container runat="server" ID="Container4" Layout="FitLayout" ResizeHandles="All" HeightSpec="100%" WidthSpec="100%" StyleSpec="Width:100%" MonitorResize="true" AnchorVertical="100%" AnchorHorizontal="100%" Region="Center">
                                    <Items>
                                        <ext:GridPanel
                                            ID="GridPanel1"
                                            runat="server"
                                            RowLines="true"
                                            Title="Auditorias Cadastradas"
                                            TitleAlign="Center"
                                            ColumnLines="true"
                                            Width="825"
                                            StoreID="storeUsuarios">
                                            <DockedItems>
                                                <ext:Toolbar runat="server" Dock="top" Width="50">
                                                    <Items>
                                                        <ext:Button ID="Button3" runat="server" Text="Nova Auditoria" Icon="Add">
                                                            <Listeners>
                                                                <Click Handler="#{WinAuditoria}.show(), #{strItemSelector1}.reload();" />
                                                            </Listeners>
                                                        </ext:Button>
                                                    </Items>
                                                </ext:Toolbar>
                                            </DockedItems>
                                            <ColumnModel>
                                                <Columns>
                                                    <ext:RowNumbererColumn runat="server" Width="30" />
                                                    <ext:Column ID="Column11" runat="server" Text="Nome" DataIndex="Nome" Width="150" />
                                                    <ext:Column ID="Column12" runat="server" Text="Departamento" DataIndex="Departamento" Width="200" />
                                                    <ext:Column ID="Column13" runat="server" Text="Cargo" DataIndex="Cargo" Width="150" />
                                                    <ext:Column ID="Column14" runat="server" Text="E-mail" DataIndex="Email" Width="230" />
                                                    <ext:Column ID="Column15" runat="server" Hidden="true" DataIndex="Ativo" />
                                                    <ext:CommandColumn runat="server" Width="70">
                                                        <Commands>
                                                            <ext:GridCommand Icon="Key" CommandName="Senha" ToolTip-Text="Alterar Senha" />
                                                            <ext:GridCommand Icon="Accept" CommandName="Ativar" ToolTip-Text="Ativar usuário" Hidden="true" />
                                                            <ext:GridCommand Icon="Cross" CommandName="Desativar" ToolTip-Text="Desativar usuário" />
                                                        </Commands>
                                                        <PrepareToolbar Fn="Tcc.javaScript.desabilitarCommandUsuarios" />
                                                        <Listeners>
                                                            <Command Handler="Tcc.javaScript.gridUsuarios(command, record, #{storeUsuarios}, #{WinAtualizarSenha}, #{formSenha});" />
                                                        </Listeners>
                                                    </ext:CommandColumn>
                                                </Columns>
                                            </ColumnModel>
                                            <BottomBar>
                                                <ext:PagingToolbar ID="PagingToolbar6" runat="server" PageSize="2" />
                                            </BottomBar>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel6" runat="server" Mode="Multi">
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <ViewConfig StripeRows="true">
                                            </ViewConfig>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Panel>


                        <%--###Tab de Usuarios###--%>
                        <ext:Panel
                            ID="TabUsuarios"
                            runat="server"
                            Title="Usuários"
                            Icon="User"
                            MonitorResize="true"
                            Stateful="true"
                            EnableColumnHide="true"
                            WidthSpec="100%">

                            <LayoutConfig>
                                <ext:HBoxLayoutConfig Align="Stretch" />
                            </LayoutConfig>
                            <Items>
                                <ext:Container runat="server" ID="Container3" Layout="FitLayout" ResizeHandles="All" HeightSpec="100%" WidthSpec="100%" StyleSpec="Width:100%" MonitorResize="true" AnchorVertical="100%" AnchorHorizontal="100%" Region="Center">
                                    <Items>
                                        <ext:GridPanel
                                            ID="GridUsuarios"
                                            runat="server"
                                            RowLines="true"
                                            Title="Usuarios Cadastrados"
                                            TitleAlign="Center"
                                            ColumnLines="true"
                                            Width="825"
                                            StoreID="storeUsuarios">
                                            <DockedItems>
                                                <ext:Toolbar runat="server" Dock="top" Width="50">
                                                    <Items>
                                                        <ext:Button ID="NovoUsuario" runat="server" Text="Novo Usuário" Icon="Add">
                                                            <Listeners>
                                                                <Click Handler="Tcc.javaScript.abrirFormUser(#{WinUsuario}, #{CadastroUsuario});" />
                                                            </Listeners>
                                                        </ext:Button>
                                                    </Items>
                                                </ext:Toolbar>
                                            </DockedItems>
                                            <ColumnModel>
                                                <Columns>
                                                    <ext:RowNumbererColumn runat="server" Width="30" />
                                                    <ext:Column ID="Column1" runat="server" Text="Nome" DataIndex="Nome" Width="150" />
                                                    <ext:Column ID="Column2" runat="server" Text="Departamento" DataIndex="Departamento" Width="200" />
                                                    <ext:Column ID="Column3" runat="server" Text="Cargo" DataIndex="Cargo" Width="150" />
                                                    <ext:Column ID="Column4" runat="server" Text="E-mail" DataIndex="Email" Width="230" />
                                                    <ext:Column ID="TextAtivo" runat="server" Hidden="true" DataIndex="Ativo" />
                                                    <ext:CommandColumn runat="server" Width="70">
                                                        <Commands>
                                                            <ext:GridCommand Icon="Key" CommandName="Senha" ToolTip-Text="Alterar Senha" />
                                                            <ext:GridCommand Icon="Accept" CommandName="Ativar" ToolTip-Text="Ativar usuário" Hidden="true" />
                                                            <ext:GridCommand Icon="Cross" CommandName="Desativar" ToolTip-Text="Desativar usuário" />
                                                        </Commands>
                                                        <PrepareToolbar Fn="Tcc.javaScript.desabilitarCommandUsuarios" />
                                                        <Listeners>
                                                            <Command Handler="Tcc.javaScript.gridUsuarios(command, record, #{storeUsuarios}, #{WinAtualizarSenha}, #{formSenha});" />
                                                        </Listeners>
                                                    </ext:CommandColumn>
                                                </Columns>
                                            </ColumnModel>
                                            <BottomBar>
                                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="2" />
                                            </BottomBar>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" Mode="Multi">
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

                <%--Janela cadastro de norma--%>
                <ext:Window runat="server" ID="WinNorma" Title="Cadastro de Norma" Closable="false" TitleAlign="Center" AutoHeight="true" Padding="5" Modal="true" Width="400px" Hidden="true" ButtonAlign="Center">
                    <Items>
                        <ext:FormPanel runat="server" ID="FormNorma" Border="false" Frame="true" BodyPadding="10" DefaultAnchor="100%">
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
                                        <ext:TextField runat="server" ID="TextNomeNorma" FieldLabel="Nome" MarginSpec="0 0 0 10" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:ComboBox runat="server" ID="ComboBoxDptoNorma" Editable="false" FieldLabel="Departamento" Width="200" StoreID="storeDepartamentos"
                                            ValueField="Id" DisplayField="Nome" EmptyText="Selecione um Departamento" MarginSpec="0 0 0 10" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />

                                    <Items>
                                        <ext:FileUploadField ID="UploadNorma" runat="server" FieldLabel="Arquivo" EmptyText="Selecione um arquivo..." Width="300" ButtonText="Anexar.." Icon="Attach" MarginSpec="0 0 0 10" />
                                    </Items>
                                </ext:FieldContainer>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" Text="Salvar" Icon="Accept">
                            <Listeners>
                                <Click Handler="if(#{FormNorma}.isValid()) {Tcc.javaScript.salvarNorma(#{TextNomeNorma}.getValue(), #{ComboBoxDptoNorma}.getValue(), #{storeCarregaNormas})};" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Fechar" Icon="Decline">
                            <Listeners>
                                <Click Handler="#{WinNorma}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>

                <%--Janela atualizar norma--%>
                <ext:Window runat="server" ID="WindowAtualizarNorma" Title="Atualizar norma" Closable="false" TitleAlign="Center" ButtonAlign="Center" AutoHeight="true" Padding="5" Modal="true" Width="320" Hidden="true">
                    <Items>
                        <ext:FormPanel runat="server" ID="FormAtualizarNorma" Frame="true" BodyPadding="10" DefaultAnchor="100%">
                            <FieldDefaults
                                LabelAlign="Top"
                                LabelWidth="100"
                                LabelStyle="font-weight:bold;" />
                            <Items>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextField runat="server" ID="TextAtualizarNormaNome" Width="150" FieldLabel="Nome" DataIndex="Nome" Editable="false" />
                                        <ext:Hidden runat="server" ID="HiddenAtualizarNormaId" DataIndex="NormaId" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:FileUploadField runat="server" ID="UpdateUploadNorma" EmptyText="Selecione um arquivo..." FieldLabel="Nova norma" Width="250" Icon="PageWhiteAcrobat" />
                                    </Items>
                                </ext:FieldContainer>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" Text="Salvar" Icon="Accept">
                            <Listeners>
                                <Click Handler="if(#{FormNorma}.isValid()) {Tcc.javaScript.atualizarNorma(#{HiddenAtualizarNormaId}.getValue(), #{TextAtualizarNormaNome}.getValue(), #{storeCarregaNormas})};" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Fechar" Icon="Decline">
                            <Listeners>
                                <Click Handler="#{WindowAtualizarNorma}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>

                <%--###Janela de cadastro de Usuario###--%>
                <ext:Window runat="server" ID="WinUsuario" Title="Cadastro de usuário" Closable="false" TitleAlign="Center" ButtonAlign="Center" AutoHeight="true" Padding="5" Modal="true" Width="400px" Height="350px" Hidden="true">
                    <Items>
                        <ext:FormPanel runat="server" ID="CadastroUsuario" Border="false" Frame="true" BodyPadding="10" DefaultAnchor="100%">
                            <Items>
                                <ext:ComboBox runat="server" ID="CmbNewUserDpto" Editable="false" FieldLabel="Departamento" Anchor="100%" StoreID="storeDepartamentos"
                                    ValueField="Id" DisplayField="Nome" EmptyText="Selecione um Departamento">
                                    <Listeners>
                                        <Select Handler="Tcc.javaScript.carregaFunc(#{CmbNewUserDpto}.getValue())" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ComboBox runat="server" ID="CmbNewUserNome" FieldLabel="Nome" Editable="false" AllowBlank="false" StoreID="storeFuncionarios" DataIndex="Nome" DisplayField="Nome" EmptyText="Carregando...">
                                    <Listeners>
                                        <Select Handler="Tcc.javaScript.carregaEmail(#{CmbNewUserNome}.getValue(), #{CmbNewUserDpto}.getValue())" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:TextField runat="server" ID="TextNewUserEmail" FieldLabel="E-mail" Editable="false" />
                                <ext:TextField runat="server" ID="TextNewUserCargo" FieldLabel="Cargo" Editable="false" />
                                <ext:ComboBox runat="server" ID="CmbNewUserTipo" FieldLabel="Permissão" Editable="false" AllowBlank="false" StoreID="storeGrupoUsuarios" DataIndex="Descricao" DisplayField="Descricao" ValueField="AcessoId" EmptyText="Carregando..." />
                                <ext:TextField runat="server" ID="TextNewUserSenha" InputType="Password" MaxLengthText="10" FieldLabel="Senha" AllowBlank="false" />
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" Text="Salvar" Icon="Accept">
                            <Listeners>
                                <Click Handler="if(#{CadastroUsuario}.isValid()) {Tcc.javaScript.cadastroUsuario(#{CmbNewUserDpto}.getValue(), #{CmbNewUserNome}.getValue(), #{TextNewUserEmail}.getValue(),
                                        #{TextNewUserCargo}.getValue(), #{CmbNewUserTipo}.getValue(), #{TextNewUserSenha}.getValue(), #{WinUsuario}, #{storeUsuarios})};" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Fechar" Icon="Decline">
                            <Listeners>
                                <Click Handler="#{WinUsuario}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>

                <%--###Janela de alteração de senha###--%>
                <ext:Window runat="server" ID="WinAtualizarSenha" Title="Alterar senha" Closable="false" TitleAlign="Center" ButtonAlign="Center" AutoHeight="true" Padding="5" Modal="true" Width="250" Hidden="true">
                    <Items>
                        <ext:FormPanel runat="server" ID="formSenha" Frame="true" BodyPadding="10" DefaultAnchor="100%">
                            <FieldDefaults
                                LabelAlign="Top"
                                LabelWidth="100"
                                LabelStyle="font-weight:bold;" />
                            <Items>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextField runat="server" ID="TextAlerarSenha" InputType="Password" MaxLength="10" MaxLengthText="10" MarginSpec="0 0 0 20" FieldLabel="Nova Senha" Anchor="80%" />
                                        <ext:TextField runat="server" ID="TextEmailSenha" Editable="false" DataIndex="Email" Hidden="true" FieldLabel="E-mail" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextField runat="server" ID="TextFieldConfirmaSenha" InputType="Password" MarginSpec="0 0 0 20" MaxLength="10" MaxLengthText="10" FieldLabel="Confirmar Senha" Anchor="80%" />
                                    </Items>
                                </ext:FieldContainer>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" ID="btnSalvarSenha" Icon="Accept" Text="Salvar">
                            <Listeners>
                                <Click Handler="Tcc.javaScript.alterarSenha(#{TextEmailSenha}.getValue(), #{TextAlerarSenha}.getValue(), #{TextFieldConfirmaSenha}.getValue(), #{WinAtualizarSenha});" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnFecharSenha" Icon="Decline" Text="Fechar">
                            <Listeners>
                                <Click Handler="#{WinAtualizarSenha}.hide()" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>

                <%--Janela de procedimentos--%>
                <ext:Window runat="server" ID="WinProcedimentos" Title="Cadastro de Procedimento" Closable="false" TitleAlign="Center" ButtonAlign="Center" AutoHeight="true" Padding="5" Modal="true" Width="600px" Hidden="true">
                    <Items>
                        <ext:FormPanel runat="server" ID="FormProcedimentos" Border="false" Frame="true" BodyPadding="10" DefaultAnchor="100%">
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
                                        <ext:TextField runat="server" ID="TextProcNome" Width="200" FieldLabel="Nome" MarginSpec="0 0 0 10" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:ComboBox runat="server" ID="CmbProcNorma" Editable="false" FieldLabel="Norma" Width="200" StoreID="storeCmbNormas"
                                            ValueField="Nome" DisplayField="Nome" EmptyText="Selecione uma Norma" MarginSpec="0 0 0 10" />
                                        <ext:ComboBox runat="server" ID="CmbProcDepartamentos" Width="200" Editable="false" FieldLabel="Departamento" StoreID="storeDepartamentos"
                                            ValueField="Id" DisplayField="Nome" EmptyText="Selecione um Departamento" MarginSpec="0 0 0 40" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:DateField runat="server" ID="DateProcInicial" FieldLabel="Data Inicial" MarginSpec="0 0 0 10" />
                                        <ext:DateField runat="server" ID="DateProcFinal" FieldLabel="Data Final" MarginSpec="0 0 0 40" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:TextArea runat="server" MarginSpec="0 20 0 10" Padding="10" FieldLabel="Descrição" ID="TextDescricao" MaxLengthText="250" AllowBlank="false" />
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" Text="Salvar" Icon="Accept">
                            <Listeners>
                                <Click Handler="if(#{FormProcedimentos}.isValid()) {Tcc.javaScript.salvarProcedimento(#{TextProcNome}.getValue(), #{CmbProcNorma}.getValue(), #{CmbProcDepartamentos}.getValue(),
                                        #{DateProcInicial}.getValue(), #{DateProcFinal}.getValue(), #{TextDescricao}.getValue(), #{WinProcedimentos}, #{storeProcedimentos})};" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Fechar" Icon="Decline">
                            <Listeners>
                                <Click Handler="#{WinProcedimentos}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>

                <%--Janela de detalhes do procedimentos--%>
                <ext:Window runat="server" ID="WinDetalhes" Title="Detalhes procedimento" Closable="false" TitleAlign="Center" ButtonAlign="Center" AutoHeight="true" Padding="5" Hidden="true" Modal="true" Width="800px" Height="800">
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
                            Height="300"
                            AnchorVertical="100%"
                            Border="true"
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


                <%--Janela de detalhes norma--%>
                <ext:Window runat="server" ID="WindowHistoricoNorma" Title="Historico Norma" Closable="false" TitleAlign="Center" AutoHeight="true" Padding="5" Hidden="true" ButtonAlign="Center" Modal="true" Width="600">
                    <Items>
                        <ext:FormPanel runat="server" ID="FormHistoricoNormas" Border="false" Frame="true" BodyPadding="10" DefaultAnchor="100%">
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
                                        <ext:TextField runat="server" Width="180" FieldLabel="Nome" MarginSpec="0 0 0 10" Editable="false" DataIndex="Nome" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextField runat="server" Hidden="true" ID="TxtCaminhoNormaHistorico" DataIndex="Caminho" />
                                        <ext:Button runat="server" Text="Abrir norma" MarginSpec="0 0 0 10" Icon="PageWhiteAcrobat">
                                            <Listeners>
                                                <Click Handler="Tcc.javaScript.abrirNorma(#{TxtCaminhoNormaHistorico}.getValue());" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:FieldContainer>
                            </Items>
                        </ext:FormPanel>
                        <ext:GridPanel
                            ID="GridHistoricoNorma"
                            runat="server"
                            RowLines="true"
                            Title="Histórico de atualizações da norma"
                            TitleAlign="Center"
                            ColumnLines="true"
                            DefaultAnchor="100%"
                            Fixed="true"
                            StoreID="storeCarregaHistoricoNorma">
                            <ColumnModel>
                                <Columns>
                                    <ext:RowNumbererColumn runat="server" Width="30" />
                                    <ext:Column ID="Column9" runat="server" Text="HistoricoId" DataIndex="HistoricoNormaId" Hidden="true" />
                                    <ext:DateColumn runat="server" Format="dd/MM/yyyy HH:mm" Text="Data da Atualização" DataIndex="DataAtualizacao" Width="200" />
                                    <ext:Column runat="server" Text="Usuario" Width="180" DataIndex="Usuario" />
                                    <ext:Column ID="Column10" runat="server" Text="Usuario" DataIndex="Situacao" Width="170" />
                                </Columns>
                            </ColumnModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar5" runat="server" PageSize="2" />
                            </BottomBar>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel5" runat="server" Mode="Multi">
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <ViewConfig StripeRows="true">
                            </ViewConfig>
                        </ext:GridPanel>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" Text="Fechar" Icon="Decline">
                            <Listeners>
                                <Click Handler="#{WindowHistoricoNorma}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>

                <%--Janela de Auditoria--%>
                <ext:Window runat="server" AutoScroll="true" ID="WinAuditoria" Title="Cadastro de Auditoria" Closable="false" TitleAlign="Center" ButtonAlign="Center" Height="850px" Padding="5" Modal="true" Width="800px" Hidden="true">
                    <Items>
                        <ext:FormPanel runat="server" ID="FormPanel1" Border="false" Frame="true" BodyPadding="5" DefaultAnchor="100%">
                            <FieldDefaults
                                LabelAlign="Top"
                                LabelWidth="100"
                                LabelStyle="font-weight:bold;" />
                            <Defaults>
                                <ext:Parameter Name="margin" Value="0 0 5 0" Mode="Value" />
                            </Defaults>
                            <Items>
                                <ext:FieldContainer
                                    runat="server"
                                    Padding="10"
                                    LabelStyle="font-weight:bold;padding:0;"
                                    Layout="HBoxLayout">
                                    <FieldDefaults LabelAlign="Top" />
                                    <Items>
                                        <ext:TextField runat="server" ID="TextField3" Width="200" FieldLabel="Nome auditor" MarginSpec="0 0 0 10" />
                                        <%-- <ext:uploa runat="server" ID="UploadAuditor" Icon="DiskUpload" FieldLabel="Documento Auditor"  MarginSpec="0 0 0 20" />--%>
                                        <ext:FileUploadField ID="UploadAuditor" runat="server" FieldLabel="Documento Auditor" EmptyText="Selecione um arquivo..." Width="300" ButtonText="Anexar.." Icon="Attach" MarginSpec="0 0 0 10" />
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldSet
                                    runat="server"
                                    Title="Norma-Auditoria"
                                    Layout="AnchorLayout"
                                    DefaultAnchor="100%">
                                    <Items>

                                        <ext:FieldContainer
                                            runat="server"
                                            Padding="10"
                                            LabelStyle="font-weight:bold;padding:0;"
                                            Layout="HBoxLayout">
                                            <FieldDefaults LabelAlign="Top" />
                                            <Items>
                                                <ext:ItemSelector
                                                    ID="ItemSelector1"
                                                    runat="server"
                                                    FieldLabel="Selecionar normas"
                                                    AllowBlank="false"
                                                    MsgTarget="Side"
                                                    FromTitle="Normas"
                                                    ToTitle="Auditoria"
                                                    ValueField="Caminho"
                                                    DisplayField="Nome"
                                                    Width="500">
                                                    <Store>
                                                        <ext:Store runat="server" ID="strItemSelector1" AutoLoad="true" AutoDataBind="true" OnReadData="strItemSelector1_ReadData">
                                                            <Model>
                                                                <ext:Model ID="Model1" runat="server" IDProperty="Nome">
                                                                    <Fields>
                                                                        <ext:ModelField Name="Nome" />
                                                                        <ext:ModelField Name="Caminho" />
                                                                    </Fields>
                                                                </ext:Model>
                                                            </Model>
                                                        </ext:Store>
                                                    </Store>
                                                </ext:ItemSelector>
                                            </Items>
                                        </ext:FieldContainer>
                                    </Items>
                                </ext:FieldSet>
                                <ext:FieldSet
                                    runat="server"
                                    Title="Entrega da Auditoria"
                                    Layout="AnchorLayout"
                                    DefaultAnchor="100%">
                                    <Items>
                                        <ext:FieldContainer
                                            runat="server"
                                            Padding="10"
                                            LabelStyle="font-weight:bold;padding:0;"
                                            Layout="HBoxLayout">
                                            <FieldDefaults LabelAlign="Right" />
                                            <Items>
                                                <ext:Checkbox runat="server" FieldLabel="Evidencias" MarginSpec="0 0 0 10" />
                                                <ext:Checkbox runat="server" FieldLabel="Normas" MarginSpec="0 0 0 10" />
                                            </Items>
                                        </ext:FieldContainer>
                                        <ext:FieldContainer
                                            runat="server"
                                            Layout="HBoxLayout"
                                            Padding="20">
                                            <FieldDefaults LabelAlign="Right" />
                                            <Items>
                                                <ext:DateField runat="server" MarginSpec="0 0 0 10" ID="DateField5" FieldLabel="De" LabelWidth="30" />
                                                <ext:DateField runat="server" ID="DateField6" FieldLabel="Até" MarginSpec="0 0 0 10" LabelWidth="30" />
                                            </Items>
                                        </ext:FieldContainer>
                                    </Items>
                                </ext:FieldSet>
                                <ext:FieldSet
                                    runat="server"
                                    Title="Usuário"
                                    Layout="AnchorLayout"
                                    DefaultAnchor="100%">
                                    <Items>
                                        <ext:FieldContainer
                                            runat="server"
                                            Layout="HBoxLayout"
                                            Padding="20">
                                            <FieldDefaults LabelAlign="Right" />
                                            <Items>
                                              <ext:TextField runat="server" ID="UsuarioAuditor" InputType="Email" FieldLabel="Usuário"/>
                                            </Items>
                                        </ext:FieldContainer>
                                        <ext:FieldContainer
                                            runat="server"
                                            Layout="HBoxLayout"
                                            Padding="20">
                                            <FieldDefaults LabelAlign="Right" />
                                            <Items>
                                              <ext:TextField runat="server" ID="SenhaAuditor" FieldLabel="Senha" />
                                            </Items>
                                        </ext:FieldContainer>
                                         <ext:FieldContainer
                                            runat="server"
                                            Layout="HBoxLayout"
                                            Padding="20">
                                            <FieldDefaults LabelAlign="Top" />
                                            <Items>
                                                <ext:DateField runat="server" MarginSpec="0 0 0 10" ID="DataPublicacao" FieldLabel="Data Publicação" LabelWidth="30" Selectable="false"/>
                                                <ext:DateField runat="server" ID="DateField4" FieldLabel="Data de Acesso Limite" MarginSpec="0 0 0 10" LabelWidth="30" />
                                            </Items>
                                        </ext:FieldContainer>
                                         <ext:FieldContainer
                                            runat="server"
                                            Layout="HBoxLayout"
                                            Padding="20">
                                            <FieldDefaults LabelAlign="Right" />
                                            <Items>
                                               <ext:Button runat="server" Text="Gerar Usuário" Icon="User" >  
                                                   <Listeners>
                                                       <Click Handler="Tcc.javaScript.criaUser();" />
                                                   </Listeners>
                                               </ext:Button>
                                            </Items>
                                        </ext:FieldContainer>
                                        
                                    </Items>
                                    
                                </ext:FieldSet>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" Text="Salvar" Icon="Accept">
                            <Listeners>
                                <Click Handler="if(#{FormProcedimentos}.isValid()) {Tcc.javaScript.salvarProcedimento(#{TextProcNome}.getValue(), #{CmbProcNorma}.getValue(), #{CmbProcDepartamentos}.getValue(),
                                        #{DateProcInicial}.getValue(), #{DateProcFinal}.getValue(), #{TextDescricao}.getValue(), #{WinProcedimentos}, #{storeProcedimentos})};" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Fechar" Icon="Decline">
                            <Listeners>
                                <Click Handler="#{WinAuditoria}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>
            </Items>
        </ext:Viewport>

    </form>
</body>
</html>

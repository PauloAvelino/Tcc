<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SGSI.Web.Application.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../Css/Css.css" rel="stylesheet" />
    <script src="../JS/Telas.js"></script>
</head>
<body>

    <ext:ResourceManager ID="ResourceManager1" runat="server" DirectMethodNamespace="SGSI" Locale="pt-BR" Theme="Default" />

    <ext:Viewport ID="Viewport1" runat="server">
        <LayoutConfig>
            <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
        </LayoutConfig>
        <Items>
         
            <ext:FormPanel ID="FormLogin"
                runat="server"
                Title="Safe Procedure"
                Url=""
                Width="350px"
                Frame="true"
                BodyPadding="10"
                DefaultAnchor="100%"
                TitleAlign="Center">
                <Items>

                    <ext:TextField ID="TextLoginEmail"
                        runat="server"
                        AllowBlank="false"
                        FieldLabel="E-mail"
                        Vtype="email"
                        Name="user"
                        EmptyText="e-mail" />

                    <ext:TextField ID="TextLoginSenha"
                        runat="server"
                        AllowBlank="false"
                        FieldLabel="Senha"
                        Name="pass"
                        EmptyText="senha"
                        InputType="Password" />
                </Items>

                <Buttons>
                    <ext:Button runat="server" Text="Entrar" Icon="Accept" StyleHtmlCls="min-width: 75px; right: auto; left: 306px; ">
                    <Listeners>
                        <Click Handler="if(#{FormLogin}.isValid()) {Tcc.javaScript.login(#{TextLoginEmail}.getValue(), #{TextLoginSenha}.getValue())};"/>
                    </Listeners>
                    </ext:Button>
                </Buttons>

            </ext:FormPanel>
        </Items>
    </ext:Viewport>

</body>
</html>

﻿<%@ Page Language="C#" MasterPageFile="~/Templates/AuthentificatedPage.Master" AutoEventWireup="true" CodeBehind="NewStatementSelection.aspx.cs" Inherits="rt.srz.ui.pvp.Pages.NewStatementSelection"
  EnableEventValidation="false" %>

<%@ Register Src="~/Controls/StatementSelectionWizardControl.ascx" TagName="Wizard" TagPrefix="uc" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <ajaxToolkit:ToolkitScriptManager ID="ScriptManager" runat="server" EnableScriptLocalization="True" EnableScriptGlobalization="True" EnablePageMethods="true" CombineScripts="False" ScriptMode="Release" />
  <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/jquery-2.1.0.js") %>"></script>
  <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/jquery-migrate-1.2.1.js") %>"></script>
  <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/jquery.meio.mask.js") %>"></script>
  <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/jquery.Jcrop.js") %>"></script>
  <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/jquery.limitkeypress.js") %>"></script>
  <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/DateTextBox.js") %>"></script>
  <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/LFM.js") %>"></script>
  <br />
  <div class="wizardContent">
    <uc:Wizard ID="StatementSelectionWizard" runat="server" />
  </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Housing_Disrepair_Calculator.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="Housing_Disrepair_Calculator" %>
<!DOCTYPE html>
<html xmlns="https://www.w3.org/1999/xhtml">
<head>
<link rel="icon" href="https://www.duncanlewis.co.uk/images/favicon.ico" type="image/x-icon" /> 
<link rel="shortcut icon" href="https://www.duncanlewis.co.uk/images/favicon.ico" type="image/x-icon" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0" /> 
<title>Housing Disrepair Calculator</title>
<meta name="description" content="Housing Disrepair Calculator calculates the the cost that you can clain against disrepair"/>
<meta name="keywords" content="Home that is safe, Good state of repair, Disrepair compensation calculator, Housing disrepair solicitor, Uninhabitable rooms, Landlords fail to fulfil their duties, Local Authority disrepair, Housing Association disrepair, Private Landlord disrepair, Personal belongings damaged by disrepair, Serious risk of harm to health and safety, Housing Solicitor, Housing lawyer, Disrepair solicitor, Landlord issues, Dampness in property, Claim for disrepair, Claim for dampness in property"/>
<meta name="ROBOTS" content="INDEX, FOLLOW"/> <meta name="YahooSeeker" content="INDEX, FOLLOW"/> <meta name="msnbot" content="INDEX, FOLLOW"/> <meta name="googlebot" content="INDEX, FOLLOW"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<link href="/Content/site.css" rel="stylesheet"/>
    <link href="/Content/bootstrap.css" rel="stylesheet"/>
    <script src="/Scripts/modernizr-2.6.2.js"></script>
    <script src="/Scripts/jquery-1.10.2.js"></script>
     <script src="/Scripts/bootstrap.js"></script>
     <script src="/Scripts/respond.js"></script>
     <script src="/Scripts/CSSRefresh.js"></script>
    <script src="/Scripts/Custom.js"></script>
<link href="https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,300i,700|Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet" />
<link href="https://fonts.googleapis.com/css?family=Dosis" rel="stylesheet" />
    <link href="/Content/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
<script src="/Scripts/auto-update-chrome.js"></script>
</head>
<body><div class="row nopadding">
<div class="col-sm-12 col-md-12 col-sm-12 col-xs-12 nopadding">
<div class="row nopadding">
<div w3-include-html="/MainNav.html"></div>
</div>
            <div class="row nopadding">
                <div class="col-lg-8 col-sm-12 col-xs-12 col-lg-offset-2 applyblock centerdiv header nopadding">
                    <div class="row nopadding">
                        <div class="col-sm-4 col-xs-5 nopadding">
                            <a href="/index.html"><img src="/Images/DL_Logo.PNG" class="img-responsive dllogo" /></a>
                        </div>
                        <div class="col-sm-8 col-xs-7 nopadding">
                            <div class="headerright">
<form method="get" action="https://www.google.co.uk/search">
                                <p><font class="lightcyantext">Have a question?</font><br /><span class="fa fa-phone"></span>033 3772 0409</p>
                                <input type="text" name="q" id="q" class="form-control hidden-xs" />
                                <button name="searchgoogle" id="searchgoogle" class="btn btn-primary hidden-xs" value="search"><span class="fa fa-search"></span></button>
</form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

<div class="row nopadding crouselsection dept_Housing deptbordercolor">
    <div class="col-md-12 col-lg-12 col-sm-12 nopadding">
        <div id="deptpage-carousel" class="carousel slide nopadding" data-ride="carousel" data-interval="18000">
            <ol class="carousel-indicators">
                <li class="dept_Housing kolor" data-target="#deptpage-carousel" data-slide-to="0" ></li>
                <li class="dept_Housing kolor" data-target="#deptpage-carousel" data-slide-to="1" ></li>
                <li class="dept_Housing kolor" data-target="#deptpage-carousel" data-slide-to="2" ></li>
                <li class="dept_Housing kolor" data-target="#deptpage-carousel" data-slide-to="3" ></li>
            </ol>
            <div class="carousel-inner">
                <div class="item">
                    <a href="">
                        <img src="/WebBanners/Housing1.jpg" class="visible-lg visible-md visible-sm hidden-xs"  />
                        <img src="/WebBanners/Housing1_M.jpg" class="hidden-lg hidden-md hidden-sm visible-xs" />
                    </a>
                    <div class="deptpage-carousel-caption">
                        <h3 class="dept_Housing forecolorlight">Landlord and Tenant Advice</h3>
                        <h4 class="dept_Housing forecolorlight deptbordercolorlight">We offer advice and assistance to landlords and tenants so that everybody understands the rules and regulations involved.</h4>
                    </div>
                </div>
                <div class="item">
                    <a href="">
                        <img src="/WebBanners/Housing2.jpg" class="visible-lg visible-md visible-sm hidden-xs"  />
                        <img src="/WebBanners/Housing2_M.jpg" class="hidden-lg hidden-md hidden-sm visible-xs" />
                    </a>
                    <div class="deptpage-carousel-caption">
                        <h3 class="dept_Housing forecolorlight">Supporting and Understanding</h3>
                        <h4 class="dept_Housing forecolorlight deptbordercolorlight">We are sympathetic to the housing difficulties that can arise and are here to help and support you.  </h4>
                    </div>
                </div>
                <div class="item">
                    <a href="">
                        <img src="/WebBanners/Housing4.jpg" class="visible-lg visible-md visible-sm hidden-xs"  />
                        <img src="/WebBanners/Housing4_M.jpg" class="hidden-lg hidden-md hidden-sm visible-xs" />
                    </a>
                    <div class="deptpage-carousel-caption">
                        <h3 class="dept_Housing forecolorlight">The Highest Standards</h3>
                        <h4 class="dept_Housing forecolorlight deptbordercolorlight">We're here to help those whose landlords have allowed properties to fall into disrepair. </h4>
                    </div>
                </div>
                <div class="item">
                    <a href="">
                        <img src="/WebBanners/Housing3.jpg" class="visible-lg visible-md visible-sm hidden-xs"  />
                        <img src="/WebBanners/Housing3_M.jpg" class="hidden-lg hidden-md hidden-sm visible-xs" />
                    </a>
                    <div class="deptpage-carousel-caption">
                        <h3 class="dept_Housing forecolorlight">We have the key to success</h3>
                        <h4 class="dept_Housing forecolorlight deptbordercolorlight">Our Housing Solicitors have a wealth of knowledge and extensive experience in all manners of housing law matters. </h4>
                    </div>
                </div>
            </div>
            <a class="left carousel-control" href="#deptpage-carousel" data-slide="prev">
                <span class="fa fa-caret-left deptcarouselcontrol dept_Housing forecolor"></span>
            </a>
            <a class="right carousel-control" href="#deptpage-carousel" data-slide="next">
                <span class="fa fa-caret-right deptcarouselcontrol dept_Housing forecolor"></span>
            </a>
        </div>
    </div>
    <div class="parentrowoffixedrow">
        <div class="row nopadding dept_Housing kolor deptheading" data-spy="affix" data-offset-top="500">
            <div class="col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv">
                <h1 class="dept_Housing">Housing Disrepair Calculator</h1>
            </div>
        </div>
    </div>
</div>

<div class="row nopadding">
    <div class="col-sm-8 col-xs-12 col-sm-offset-2 nopadding applyblock centerdiv">
        <div class="row nopadding">
            <div class="col-sm-12 col-md-7 col-xs-12 col-md-offset-5 depttabs">
                <a class="dept_Housing forecolor lightkolor over" href="/housing_ourteam.html">Our Team<span class="fa fa-users"></span></a>
                <a class="dept_Housing forecolor lightkolor over" href="/housing_news.html">News<span class="fa fa-newspaper-o"></span></a>
                <a class="dept_Housing forecolor lightkolor over" href="/housing_articles.html">Articles<span class="fa fa-book"></span></a>
                <a class="dept_Housing forecolor lightkolor over" href="/Housing-Video.html">Videos<span class="fa fa-video-camera"></span></a>
            </div>
    </div>
</div>
</div>
<div class="row deptreverseband dept_Housing lightkolor  nopadding">
    <div class="col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv">
        <div class="row nopadding">
            <div class="col-sm-9 col-xs-12 col-sm-offset-3 breadcrumbs">
       <p><a  class="dept_Housing forecolor" href="/index.html"><p>Home</a><span class="fa fa-angle-double-right"></span><a  class="dept_Housing forecolor" href="/housing.html"><p>Housing</a><span class="fa fa-angle-double-right"></span>Housing</p>
            </div>
        </div>
    </div>
</div>
<div class="dept_Housing row nopadding">
    <div class="col-sm-8 col-xs-12 col-lg-offset-2 nopadding applyblock centerdiv">
        <div class="row nopadding">
            <div class="col-sm-3 col-xs-12 nopadding">
<div id="deptmenu" class="dept_Housing">
<div class="panel panel-default deptbordercolor">
                        <div class="dept_Housing deptbordercolor forecolor deptmenumainheading nopadding">
<a data-toggle="collapse" href="#deptnavigationmenu">Housing Services<span class="fa fa-caret-down"></span></a>
                        </div>
                        <div id="deptnavigationmenu" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <ul>
<li class="lastnode"><a  href="/housing.html"><p>Overview</p><span></span></a></li>
<li><a data-toggle="collapse"" href="#AdviceforTenantsLevel1"><p>Advice for Tenants</p><span></span></a>
<ul class="collapse in " id="AdviceforTenantsLevel1">
<li><a data-toggle="collapse"" href="#RepairsLevel2"><p>Repairs</p><span></span></a>
<ul class="collapse in " id="RepairsLevel2">
<li class="lastnode"><a  class="active"  href="/Disrepair-Local-Authorities.html"><p>Disrepair Local Authorities</p><span></span></a></li>
<li class="lastnode"><a  href="/Disrepair-Housing-Association.html"><p>Disrepair Housing Association</p><span></span></a></li>
<li class="lastnode"><a  href="/Repairs-to-be-carried-out-by-a-landlord.html"><p>Disrepair Private Landlords</p><span></span></a></li>
<li class="lastnode"><a  href="/Remedies-in-County-Courts.html"><p>Remedies in County Courts</p><span></span></a></li>
<li class="lastnode"><a  href="/Actions-in-Magistrates-Court.html"><p>Actions in Magistrates Court</p><span></span></a></li>
<li class="lastnode"><a  href="/Legal-Aid-For-Disrepair-Claims.html"><p>Legal Aid For Disrepair Claims</p><span></span></a></li>
<li class="lastnode"><a  href="/No-Win-No-Fee-Claims.html"><p>No Win No Fee Claims</p><span></span></a></li>
<li class="lastnode"><a  href="/No-Hot-Water-or-Heating.html"><p>No Hot Water or Heating</p><span></span></a></li>
<li class="lastnode"><a  href="/Water-Damage.html"><p>Water Damage</p><span></span></a></li>
<li class="lastnode"><a  href="/Tower-Block-Repairs.html"><p>Tower Block Repairs</p><span></span></a></li>
<li class="lastnode"><a  href="/Mould.html"><p>Mould</p><span></span></a></li>
<li class="lastnode"><a  href="/Asbestos.html"><p>Asbestos</p><span></span></a></li>
<li class="lastnode"><a  href="/Personal-Injury-arising-from-disrepair.html"><p>Personal Injury</p><span></span></a></li>
<li class="lastmenuitem lastnode"><a  href="/Problems-During-Repairs.html"><p>Problems During Repairs</p><span></span></a></li>
</ul>
</li>
<li><a data-toggle="collapse" class="collapsed" " href="#HomelessnessLevel2"><p>Homelessness</p><span></span></a>
<ul class="collapse" id="HomelessnessLevel2">
<li class="lastnode"><a  href="/The-Homelessness-Test.html"><p>The Homelessness Test</p><span></span></a></li>
<li class="lastnode"><a  href="/Homelessness-Accommodation-Duties.html"><p>Homelessness Accommodation Duties</p><span></span></a></li>
<li class="lastnode"><a  href="/Homelessness-Review.html"><p>Homelessness Review</p><span></span></a></li>
<li class="lastnode"><a  href="/Homelessness-Appeals.html"><p>Homelessness Appeals</p><span></span></a></li>
<li class="lastnode"><a  href="/Challenging-Local-Authority.html"><p>Challenging Local Authority</p><span></span></a></li>
<li class="lastmenuitem lastnode"><a  href="/Funding-Housing.html"><p>Funding</p><span></span></a></li>
</ul>
</li>
<li><a data-toggle="collapse" class="collapsed" " href="#UnlawfulEvictionLevel2"><p>Unlawful Eviction</p><span></span></a>
<ul class="collapse" id="UnlawfulEvictionLevel2">
<li class="lastnode"><a  href="/Unlawful-Eviction-By-Private-Landlord.html"><p>Unlawful Eviction By Private Landlord</p><span></span></a></li>
<li class="lastnode"><a  href="/Unlawful-Eviction-By-Local-Authorities.html"><p>Unlawful Eviction By Local Authorities</p><span></span></a></li>
<li class="lastnode"><a  href="/Revenge-Eviction.html"><p>Revenge Eviction</p><span></span></a></li>
<li class="lastnode"><a  href="/Funding-Unlawful-Eviction-Matters.html"><p>Funding Unlawful Eviction Matters</p><span></span></a></li>
<li class="lastmenuitem lastnode"><a  href="/Injunctions.html"><p>Obtaining an Injunction</p><span></span></a></li>
</ul>
</li>
<li><a data-toggle="collapse" class="collapsed" " href="#PossessionLevel2"><p>Possession</p><span></span></a>
<ul class="collapse" id="PossessionLevel2">
<li class="lastnode"><a  href="/Section--21-Possession-Claims.html"><p>Section  21 Possession Claims</p><span></span></a></li>
<li class="lastnode"><a  href="/Rent--Arrears-–-Local-Authorities.html"><p>Rent  Arrears – Local Authorities</p><span></span></a></li>
<li class="lastnode"><a  href="/Rent--Arrears-–-Private-Landlord.html"><p>Rent  Arrears – Private Landlord</p><span></span></a></li>
<li class="lastnode"><a  href="/Rent--Arrears-–-Housing-Association.html"><p>Rent  Arrears – Housing Association</p><span></span></a></li>
<li class="lastnode"><a  href="/Breach--Of-Tenancy-Agreement.html"><p>Breach  Of Tenancy Agreement</p><span></span></a></li>
<li class="lastnode"><a  href="/Defending-Possession-Claims.html"><p>Defending Possession Claims</p><span></span></a></li>
<li class="lastnode"><a  href="/Mortgage-Repossession-Claims.html"><p>Mortgage Repossession Claims</p><span></span></a></li>
<li class="lastnode"><a  href="/Eviction-Notice.html"><p>Eviction Notice</p><span></span></a></li>
<li class="lastmenuitem lastnode"><a  href="/Funding-Possession-Claims.html"><p>Funding Possession Claims</p><span></span></a></li>
</ul>
</li>
<li><a data-toggle="collapse" class="collapsed" " href="#LandlordDisputeLevel2"><p>Landlord Dispute</p><span></span></a>
<ul class="collapse" id="LandlordDisputeLevel2">
<li class="lastnode"><a  href="/Tenancy-Deposit-Dispute.html"><p>Tenancy Deposit Dispute</p><span></span></a></li>
<li class="lastmenuitem lastnode"><a  href="/Breach-of-Tenancy-Agreement-Dispute.html"><p>Breach of Tenancy Agreement Dispute</p><span></span></a></li>
</ul>
</li>
<li class="lastmenuitem" ><a data-toggle="collapse" class="collapsed" " href="#HarassmentAntisocialbehaviourLevel2"><p>Harassment  & Anti-social behaviour</p><span></span></a>
<ul class="collapse" id="HarassmentAntisocialbehaviourLevel2">
<li class="lastnode"><a  href="/Harassment-by-Landlord.html"><p>Harassment by Landlord</p><span></span></a></li>
<li class="lastnode"><a  href="/Neighbour-Disputes-Solicitor.html"><p>Harassment By Neighbours</p><span></span></a></li>
<li class="lastmenuitem lastnode"><a  href="/Anti-Social-Behaviour.html"><p>Anti-Social Behaviour</p><span></span></a></li>
</ul>
</li>
</ul>
</li>
<li><a data-toggle="collapse" class="collapsed" " href="#AdviceforLandlordsLevel1"><p>Advice for Landlords</p><span></span></a>
<ul class="collapse" id="AdviceforLandlordsLevel1">
<li><a data-toggle="collapse" class="collapsed" " href="#DisrepairLandlordLevel2"><p>Disrepair - Landlord</p><span></span></a>
<ul class="collapse" id="DisrepairLandlordLevel2">
<li class="lastnode"><a  href="/Defending-Disrepair-Claims.html"><p>Defending Disrepair Claims</p><span></span></a></li>
<li class="lastmenuitem lastnode"><a  href="/Environmental-Act-.html"><p>Environmental Act </p><span></span></a></li>
</ul>
</li>
<li><a data-toggle="collapse" class="collapsed" " href="#UnlawfulEvictionLandlordLevel2"><p>Unlawful Eviction - Landlord</p><span></span></a>
<ul class="collapse" id="UnlawfulEvictionLandlordLevel2">
<li class="lastmenuitem lastnode"><a  href="/Defending-An-Unlawful--Eviction-Claim.html"><p>Defending An Unlawful  Eviction Claim</p><span></span></a></li>
</ul>
</li>
<li><a data-toggle="collapse" class="collapsed" " href="#LandlordClaimLevel2"><p>Landlord Claim</p><span></span></a>
<ul class="collapse" id="LandlordClaimLevel2">
<li class="lastnode"><a  href="/Tenant-Eviction.html"><p>Tenant Eviction</p><span></span></a></li>
<li class="lastnode"><a  href="/S21-Notices.html"><p>Section 21 Notice</p><span></span></a></li>
<li class="lastnode"><a  href="/Assured--Shorthold-Tenancy-Claims.html"><p>Assured  Shorthold Tenancy Claims</p><span></span></a></li>
<li class="lastmenuitem lastnode"><a  href="/Section-8-Housing-Act.html"><p>Section 8 Housing Act</p><span></span></a></li>
</ul>
</li>
<li class="lastmenuitem" ><a data-toggle="collapse" class="collapsed" " href="#HarassmentClaimLevel2"><p>Harassment Claim</p><span></span></a>
<ul class="collapse" id="HarassmentClaimLevel2">
<li class="lastnode"><a  href="/Defending-Harassment-Claims.html"><p>Defending Harassment Claims</p><span></span></a></li>
<li class="lastnode"><a  href="/Civil-Penalties-For-No-Right--To-Rent.html"><p>Civil Penalties For No Right  To Rent</p><span></span></a></li>
<li class="lastmenuitem lastnode"><a  href="/Criminal-Penalties-For-No--Right-To-Rent.html"><p>Criminal Penalties For No  Right To Rent</p><span></span></a></li>
</ul>
</li>
</ul>
</li>
<li class="lastmenuitem" ><a data-toggle="collapse" class="collapsed" " href="#PropertyDisputesLevel1"><p>Property Disputes</p><span></span></a>
<ul class="collapse" id="PropertyDisputesLevel1">
<li class="lastnode"><a  href="/Property-Disputes.html"><p>Overview</p><span></span></a></li>
<li class="lastnode"><a  href="/Lease-renewals-extensions.html"><p>Lease renewals extensions</p><span></span></a></li>
<li class="lastnode"><a  href="/Leasehold-Disputes.html"><p>Leasehold Disputes</p><span></span></a></li>
<li class="lastnode"><a  href="/Repairs-to-leaseholds.html"><p>Repairs to leaseholds</p><span></span></a></li>
<li class="lastnode"><a  href="/Right-to-manage-collective-enfranchisement.html"><p>Right to manage collective enfranchisement</p><span></span></a></li>
<li class="lastnode"><a  href="/Service-charge-disputes.html"><p>Service charge disputes</p><span></span></a></li>
<li class="lastnode"><a  href="/Restrictive-Covenant-Disputes.html"><p>Restrictive Covenant Disputes</p><span></span></a></li>
<li class="lastnode"><a  href="/Commercial-Landlord-and-Tenant-Disputes.html"><p>Commercial Landlord and Tenant Disputes</p><span></span></a></li>
<li class="lastnode"><a  href="/Trespassers.html"><p>Trespassers</p><span></span></a></li>
<li class="lastnode"><a  href="/Dilapidations-and-Repairing-Claims-and-Obligations.html"><p>Dilapidations and Repairing Claims and Obligations</p><span></span></a></li>
<li class="lastnode"><a  href="/Possession-actions.html"><p>ForfeiturePossession actions</p><span></span></a></li>
<li class="lastnode"><a  href="/Planning-Permission-and-Refusals.html"><p>Planning Permission and Refusals</p><span></span></a></li>
<li class="lastnode"><a  href="/Actions-in-trespass.html"><p>Actions in trespass</p><span></span></a></li>
<li class="lastnode"><a  href="/Adverse-possession-claims.html"><p>Adverse possession claims</p><span></span></a></li>
<li class="lastnode"><a  href="/Building-disputes-Solicitor.html"><p>Building disputes Solicitor</p><span></span></a></li>
<li class="lastnode"><a  href="/Boundary-disputes-Solicitor.html"><p>Boundary disputes Solicitor</p><span></span></a></li>
<li class="lastnode"><a  href="/Co-ownership-disputes-Solicitor.html"><p>Co-ownership disputes Solicitor</p><span></span></a></li>
<li class="lastnode"><a  href="/Japanese-knotweed-disputes.html"><p>Japanese knotweed disputes</p><span></span></a></li>
<li class="lastnode"><a  href="/Negligence-Housing.html"><p>Negligence</p><span></span></a></li>
<li class="lastnode"><a  href="/Ownership-disputes-and-shares-in-property.html"><p>Ownership disputes and shares in property</p><span></span></a></li>
<li class="lastnode"><a  href="/Party-Wall-Act-disputes-Solicitor.html"><p>Party Wall Act disputes Solicitor</p><span></span></a></li>
<li class="lastnode"><a  href="/Property-repairs-Solicitor.html"><p>Property repairs Solicitor</p><span></span></a></li>
<li class="lastnode"><a  href="/Rights-of-way-Solicitor.html"><p>Rights of way Solicitor</p><span></span></a></li>
<li class="lastnode"><a  href="/Judicial-Review-in-homelessness-matters.html"><p>Judicial Review in homelessness matters</p><span></span></a></li>
<li class="lastnode"><a  href="/Possession-claims-Solicitor-Mortgage-arrears.html"><p>Possession claims Solicitor- Mortgage arrears</p><span></span></a></li>
<li class="lastmenuitem lastnode"><a  href="/Issue-of-Adverse-Possession.html"><p>Issue of Adverse Possession</p><span></span></a></li>
</ul>
</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-sm-9 col-xs-12">
                <div id="container">

<form id="form1" runat="server">
    <div class="col-md-12" style="margin: 5px; padding: 5px;" id="mainDiv" runat="server">
        <div class="panel panel-default">
            <div class="panel-heading dept_Housing kolor forecolorlight">
                    Housing Disrepair Calculator
            </div>
            <div class="panel-body">
                <p>
                    Everybody deserves to live in a home that is safe and in a good state of repair.
                        Unfortunately some landlords fail to fulfil their duties. We also act for leaseholders
                        in relation to claims for disrepair and compensation against freeholders.</p>
                        <p>&nbsp;</p>
                <p>
                    Please try our disrepair compensation calculator which allows you to see what
                        compensation you may be entitled to receive due to your landlord’s failure to keep
                        your home in a good state of repair.</p>
                        <p>&nbsp;</p>
                
                <table class="table table-condensed">
                    <tr>
                        <td>
                            1) How much is your weekly rent? (to the nearest hundred)
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlRent" runat="server" CssClass="form-control">
                                 <asp:ListItem>Please Select</asp:ListItem>
                                    <asp:ListItem Text="£100" Value="100"></asp:ListItem>
                                    <asp:ListItem Text="£200 " Value="200"></asp:ListItem>
                                    <asp:ListItem Text="£300" Value="300"></asp:ListItem>
                                    <asp:ListItem Text="£400" Value="400"></asp:ListItem>
                                    <asp:ListItem Text="£500" Value="500"></asp:ListItem>
                                    <asp:ListItem Text="£600" Value="600"></asp:ListItem>
                                   <asp:ListItem Text="£700" Value="700"></asp:ListItem>
                                  </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Rent is required" 
                                ValidationGroup="calc" ForeColor="Red" ControlToValidate="ddlRent" 
                                    InitialValue="Please Select"></asp:RequiredFieldValidator>
                                 </div>
                                
                        </td>
                    </tr>
                    <tr>
                        <td>
                            2) How many rooms are affected by the disrepair?
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlRooms" runat="server" CssClass="form-control">
                                    <asp:ListItem>Please Select</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                               
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            3) Which rooms are affected by the disrepair?
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:ListBox ID="ddlRoomType" runat="server" SelectionMode="Multiple"
                                 CssClass="form-control" style="height:120px;">
                                    <asp:ListItem>Bedrooms</asp:ListItem>
                                    <asp:ListItem>Living rooms</asp:ListItem>
                                    <asp:ListItem>Hallway</asp:ListItem>
                                    <asp:ListItem>Bathroom</asp:ListItem>
                                    <asp:ListItem>Kitchen</asp:ListItem>
                               </asp:ListBox>
                               </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            4) How many rooms are uninhabitable?
                        </td>
                        <td>
                            <div class="form-group">
                            <asp:DropDownList ID="ddlNoRooms" runat="server" CssClass="form-control">
                                    <asp:ListItem>Please Select</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                               
                               </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            5) What is the type of disrepair?
                        </td>
                        <td>
                            <div class="form-group">

                             <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple"
                                 CssClass="form-control" style="height:150px;">
                                    <asp:ListItem>Inadequate heating and/or hot water</asp:ListItem>
                                    <asp:ListItem>Damp</asp:ListItem>
                                    <asp:ListItem>Roof Leaks</asp:ListItem>
                                    <asp:ListItem>Water Leaks</asp:ListItem>
                                    <asp:ListItem>Blocked pipes and/or drains</asp:ListItem>
                                    <asp:ListItem>Structural problems</asp:ListItem>
                                    <asp:ListItem>Electrical Issues</asp:ListItem>
                                    <asp:ListItem>Others</asp:ListItem>
                               </asp:ListBox>
                                     </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            6) When did you first report the disrepair to your landlord?
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            7) How long has there been disrepair at the property? (to the nearest year)
                        </td>
                        <td>
                            <div class="form-group">
                            <asp:DropDownList ID="ddlYears" runat="server" CssClass="form-control">
                                    <asp:ListItem>Please Select</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Years are required" 
                                ValidationGroup="calc" ForeColor="Red" ControlToValidate="ddlYears" 
                                    InitialValue="Please Select"></asp:RequiredFieldValidator> 
                                </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            8) How severe is the disrepair? (5 being the highest)?
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlSeverity" runat="server" CssClass="form-control">
                                    <asp:ListItem>Please Select</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                  
                                </asp:DropDownList>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Severity are required" 
                                ValidationGroup="calc" ForeColor="Red" ControlToValidate="ddlSeverity" 
                                    InitialValue="Please Select"></asp:RequiredFieldValidator> 
                               </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            9) Has your repair been rectified?
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlRectified" runat="server" CssClass="form-control">
                                    <asp:ListItem>Please Select</asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                  
                                  
                                </asp:DropDownList></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            10) Is the disrepair causing any serious risk of harm to your health and safety?
                        </td>
                        <td>
                            <div class="form-group">
                               <asp:DropDownList ID="ddlRisk" runat="server" CssClass="form-control">
                                    <asp:ListItem>Please Select</asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                  
                                  
                                </asp:DropDownList>
                                <br />
                                <p>
                                    <strong>If &quot;Yes&quot; Please describe the risks to your health </strong>
                                </p>
                                <asp:TextBox ID="txtRiskReason" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            11) Approximately, what is the replacement value of your personal belongings that
                            have damaged by the disrepair?
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlReplacement" runat="server" CssClass="form-control">
                                <asp:ListItem Text="None" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="£100" Value="100"></asp:ListItem>
                                    <asp:ListItem Text="£200 " Value="200"></asp:ListItem>
                                    <asp:ListItem Text="£300" Value="300"></asp:ListItem>
                                    <asp:ListItem Text="£400" Value="400"></asp:ListItem>
                                    <asp:ListItem Text="£500" Value="500"></asp:ListItem>
                                    <asp:ListItem Text="£600" Value="600"></asp:ListItem>
                                    <asp:ListItem Text="£700" Value="700"></asp:ListItem>
                                    <asp:ListItem Text="£800" Value="800"></asp:ListItem>
                                    <asp:ListItem Text="£900" Value="900"></asp:ListItem>
                                    <asp:ListItem Text="£1000" Value="1000"></asp:ListItem>
                                    <asp:ListItem Text="Above £1000" Value="0"></asp:ListItem>
                                  </asp:DropDownList></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            12) Do you have rent arrears?
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlRentArrears" runat="server" CssClass="form-control">
                                    <asp:ListItem>Please Select</asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>                                                                   
                                </asp:DropDownList>
                                <br />
                                <p>
                                    <strong>If &quot;Yes&quot; Please provide details of your rent arrears </strong>
                                </p>
                                 <asp:TextBox ID="txtArrearsReason" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            13) Who is your landlord?
                        </td>
                        <td>
                            <div class="form-group">
                              <asp:DropDownList ID="ddlLandlord" runat="server" CssClass="form-control">
                                    <asp:ListItem>None</asp:ListItem>
                                    <asp:ListItem>Local Authority</asp:ListItem>
                                    <asp:ListItem>Housing Association</asp:ListItem>   
                                      <asp:ListItem>Private Landlord</asp:ListItem>                                                                  
                                </asp:DropDownList>

                               </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                        <p>&nbsp;</p>
                            <asp:Button ID="btnCalculate" runat="server" ValidationGroup="calc" 
                                Text="Calculate Claim Cost" CssClass="btn dept_Housing kolor forecolorlight" 
                                onclick="btnCalculate_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="calc" runat="server" />
                            <%--<input type="submit" class="btn btn-primary" value="Calculate Claim Cost" name="ClaimCost"
                                id="ClaimCost">--%>
                        </td>
                    </tr>
                    <!--<tr>
    <td><strong>Your claim could be worth an estimated: <span id="Totalval" style="font-size:20px; color:#036;"></span></strong></td>
    <td><button class="btn btn-default" type="button" id="button9" style="display:none"><a href="http://www.duncanlewis.co.uk/contactUs.aspx">Contact us</a></button>
    <p>Sorry, from the information provided it looks as though the cost of your repairs and damages are not sufficient for us to be able to take your case on.</p>
    </td>
  </tr>-->
                </table>
                
            </div>
        </div>
    </div>
     <div class="col-md-12" style="margin: 5px; padding: 5px;" id="LessDiv" runat="server" visible="false">
      <div class="panel-heading dept_Housing">
                <h3 class="panel-title" style="color: #fff; font-weight: bold;">
                    HOUSING DISREPAIR CALCULATOR
                </h3>
            </div>
            <br />
     <p>
     <p><b>Your claim could be worth an estimated: : <asp:Label ID="lblLess" Font-Size="20px" runat="server"></asp:Label> .<br /></b>
<br />
Sorry, from the information provided it looks as though the cost of your repairs and damages are not sufficient for us to be able to take your case on.
</p>
<br />
<asp:Button runat="server" Text="Previous" ID="btnPrevious" 
             onclick="btnPrevious_Click" CssClass="btn btn-danger" />
     </div>
      <div class="col-md-12" style="margin: 5px; padding: 5px;" id="MoreDiv" runat="server" visible="false">
      <div class="panel-heading dept_Housing kolor forekolor">
                    You can claim <asp:Literal ID="lblclaimheading" runat="server"></asp:Literal>
            </div>
            <br /><br />
            <p><b>Your claim could be worth an estimated: : <asp:Label ID="lblClaim" Font-Size="20px" runat="server"></asp:Label> .<br /></b></p>
            <br /><div class="deptcontactus dept_Housing lightkolor"><span class="dept_Housing forecolor">Please contact us to make a claim Now </span><a  class="deptcontactus dept_Housing kolor" href="/contactUs.aspx?dept=8">Contact Us</a></div><br />
     </div>
    </form>


                </div>
            </div>
        </div>
    </div>
</div>

            <div class="row footerrowtop  dept_Housing  kolor nopadding">
                <div class="col-sm-12 col-xs-12 col-sm-offset-2 applyblock centerdiv nopadding">
                    Call us now on 033 3772 0409 or click <a href="/contactUs.aspx?dept=8">here to send online enquiry</a>.
                </div>
            </div>
            <div class="row nopadding footerrowmiddle  dept_Housing  lightkolor">
                <div class="col-sm-8 col-xs-12 col-sm-offset-2 applyblock centerdiv">
                    <div class="row">
                        <div class="col-sm-2 col-xs-12 footercolumn socialicons  dept_Housing  forecolor">
                            <h6>Our Social Network</h6>
                            <a class="dept_Housing forecolor" href="https://twitter.com/DuncanLewis/" target="_blank" title="Duncan Lewis" class="socialIcons"   rel="nofollow"><span class="fa fa-twitter-square"></span></a>
                            <a class="dept_Housing forecolor" href="https://www.youtube.com/duncanlewislawyers" class="socialIcons"   rel="nofollow" ><span class="fa fa-youtube-square"></span></a>
                            <a class="dept_Housing forecolor" href="https://www.linkedin.com/companies/duncan-lewis-%26-co-solicitors-greater-london?trk=fc_badge" class="socialIcons"   rel="nofollow" ><span class="fa fa-linkedin-square"></span></a>
                            <a class="dept_Housing forecolor" href="https://www.facebook.com/duncanlewislawfirm" title="Duncan Lewis" class="socialIcons"   rel="nofollow"><span class="fa fa-facebook-square"></span></a>
                        </div>
                        <div class="col-sm-2 col-xs-12 footercolumn">
                            <h6 class=" dept_Housing  forecolor">Our Services</h6>
                            <ul>
<li><a href="/Action-Against-Public-Authorities.html">Action Against Public Authorities</a></li>
<li><a href="/uk-visas-uk-immigration.html">Business Immigration</a></li>
<li><a href="/childcare.html">Child Care</a></li>
<li><a href="/clinicalnegligence.html">Clinical Negligence</a></li>
<li><a href="/communitycare.html">Community Care</a></li>
<li><a href="/crime.html">Crime</a></li>
<li><a href="/employment.html">Employment</a></li>
<li><a href="/willsandprobate.html">Wills and Probate</a></li>
<li><a href="/family.html">Family</a></li>
<li><a href="/housing.html">Housing</a></li>
<li><a href="/immigration.html">Immigration</a></li>
<li><a href="/litigation.html">Civil Litigation</a></li>
<li><a href="/mentalhealth.html">Mental Health</a></li>
<li><a href="/personalinjury.html">Personal Injury</a></li>
<li><a href="/prisonlaw.html">Prison Law</a></li>
<li><a href="/Professionalnegligence.html">Professional Negligence</a></li>
<li><a href="/publiclaw.html">Public Law</a></li>
<li><a href="/welfarebenefits.html">Welfare Benefits</a></li>
<li><a href="/Regulatory-Law.html">Regulatory Law</a></li>
<li><a href="/motoring_law.html">Motoring Law</a></li>
<li><a href="/Commercial-Company.html">Commercial & Company</a></li>
<li><a href="/Commercial-Litigation-Disputes.html">Commercial Litigation & Disputes</a></li>
<li><a href="/Commercial-Property-Services.html">Commercial Property Services</a></li>
<li><a href="/Business-Crime-Investigation.html">Business Crime & Investigation</a></li>
<li><a href="/International-litigation.html">International Disputes</a></li>
<li><a href="/Charities.html">Charities</a></li>
                            </ul>
                        </div>
                        <div class="col-sm-2 col-xs-12 footercolumn">
                            <h6 class=" dept_Housing  forecolor">About Us</h6>
                            <ul class="footeraboutlinks">
                                <li><a href="/onlineenquiry.html">Contact Us</a></li>
                                <li><a href="/branchLocator_DL_WithMap.aspx">Find Nearest Branch</a></li>
                                <li><a href="/Our_Team_Alphabetic_A.html">Our Staff</a></li>
                                <li><a href="/about_languages.html">We Speak</a></li>
                                <li><a href="/about_managementboard.html">Management Team</a></li>
                                <li><a href="/brochures.html">Brochures</a></li>
                            </ul>
                        </div>
                        <div class="col-sm-2 col-xs-12 footercolumn">
                            <h6 class=" dept_Housing  forecolor">Offices In London</h6>
                            <ul>
<li><a href="/offices/Barking_office.html">Housing Solicitor in Barking</a></li>
<li><a href="/offices/Barnet_office.html">Housing Solicitor in Barnet</a></li>
<li><a href="/offices/Camden_office.html">Housing Solicitor in Camden</a></li>
<li><a href="/offices/Central London_office.html">Housing Solicitor in Central London</a></li>
<li><a href="/offices/Croydon_office.html">Housing Solicitor in Croydon</a></li>
<li><a href="/offices/East Ham_office.html">Housing Solicitor in East Ham</a></li>
<li><a href="/offices/Hackney_office.html">Housing Solicitor in Hackney</a></li>
<li><a href="/offices/Harrow_office.html">Housing Solicitor in Harrow</a></li>
<li><a href="/offices/Holborn_office.html">Housing Solicitor in Holborn</a></li>
<li><a href="/offices/Hounslow_office.html">Housing Solicitor in Hounslow</a></li>
<li><a href="/offices/Islington_office.html">Housing Solicitor in Islington</a></li>
<li><a href="/offices/London_office.html">Housing Solicitor in London</a></li>
<li><a href="/offices/New Cross Gate_office.html">Housing Solicitor in New Cross Gate</a></li>
<li><a href="/offices/Shepherds Bush_office.html">Housing Solicitor in Shepherds Bush</a></li>
<li><a href="/offices/Southall_office.html">Housing Solicitor in Southall</a></li>
<li><a href="/offices/Uxbridge_office.html">Housing Solicitor in Uxbridge</a></li>
<li><a href="/offices/Vauxhall_office.html">Housing Solicitor in Vauxhall</a></li>
<li><a href="/offices/Walthamstow_office.html">Housing Solicitor in Walthamstow</a></li>
<li><a href="/offices/Wembley_office.html">Housing Solicitor in Wembley</a></li>
                            </ul>
                        </div>
                        <div class="col-sm-2 col-xs-12 footercolumn">
                            <h6 class=" dept_Housing  forecolor">Offices Outside London</h6>
                            <ul>
<li><a href="/offices/Aylesbury_office.html">Housing Solicitor in Aylesbury</a></li>
<li><a href="/offices/Bedford_office.html">Housing Solicitor in Bedford</a></li>
<li><a href="/offices/Birmingham_office.html">Housing Solicitor in Birmingham</a></li>
<li><a href="/offices/Bradford_office.html">Housing Solicitor in Bradford</a></li>
<li><a href="/offices/Brighton_office.html">Housing Solicitor in Brighton</a></li>
<li><a href="/offices/Bristol_office.html">Housing Solicitor in Bristol</a></li>
<li><a href="/offices/Cambridge_office.html">Housing Solicitor in Cambridge</a></li>
<li><a href="/offices/Cardiff_office.html">Housing Solicitor in Cardiff</a></li>
<li><a href="/offices/Chatham_office.html">Housing Solicitor in Chatham</a></li>
<li><a href="/offices/Coventry_office.html">Housing Solicitor in Coventry</a></li>
<li><a href="/offices/Derby_office.html">Housing Solicitor in Derby</a></li>
<li><a href="/offices/Folkestone_office.html">Housing Solicitor in Folkestone</a></li>
<li><a href="/offices/Gravesend_office.html">Housing Solicitor in Gravesend</a></li>
<li><a href="/offices/Ipswich_office.html">Housing Solicitor in Ipswich</a></li>
<li><a href="/offices/Leeds_office.html">Housing Solicitor in Leeds</a></li>
<li><a href="/offices/Leicester_office.html">Housing Solicitor in Leicester</a></li>
<li><a href="/offices/Liverpool_office.html">Housing Solicitor in Liverpool</a></li>
                            </ul>
                        </div>
                        <div class="col-sm-2 col-xs-12 footercolumn">
                            <h6 class=" dept_Housing  forecolor">Offices Outside London</h6>
                            <ul>
<li><a href="/offices/Luton_office.html">Housing Solicitor in Luton</a></li>
<li><a href="/offices/Manchester_office.html">Housing Solicitor in Manchester</a></li>
<li><a href="/offices/Milton Keynes_office.html">Housing Solicitor in Milton Keynes</a></li>
<li><a href="/offices/Newcastle_office.html">Housing Solicitor in Newcastle</a></li>
<li><a href="/offices/Northampton_office.html">Housing Solicitor in Northampton</a></li>
<li><a href="/offices/Nottingham_office.html">Housing Solicitor in Nottingham</a></li>
<li><a href="/offices/Oxfordshire_office.html">Housing Solicitor in Oxfordshire</a></li>
<li><a href="/offices/Peterborough_office.html">Housing Solicitor in Peterborough</a></li>
<li><a href="/offices/Reading_office.html">Housing Solicitor in Reading</a></li>
<li><a href="/offices/Romford_office.html">Housing Solicitor in Romford</a></li>
<li><a href="/offices/Sheffield_office.html">Housing Solicitor in Sheffield</a></li>
<li><a href="/offices/Slough_office.html">Housing Solicitor in Slough</a></li>
<li><a href="/offices/Swansea_office.html">Housing Solicitor in Swansea</a></li>
<li><a href="/offices/Walsall_office.html">Housing Solicitor in Walsall</a></li>
<li><a href="/offices/Watford_office.html">Housing Solicitor in Watford</a></li>
<li><a href="/offices/Wolverhampton_office.html">Housing Solicitor in Wolverhampton</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row footerrowbottom nopadding">
                <div class="col-sm-8 col-sm-offset-2 applyblock centerdiv nopadding">
                    Duncan Lewis is the trading name of Duncan Lewis (Solicitors) Limited.
                    Registered Office is Spencer House, 29 Grove Hill Road, Harrow, HA1 3BN. Company Reg. No. 3718422. VAT Reg. No. 718729013.
                    A list of the company's Directors is displayed at the registered offices address. Authorised and Regulated by the Solicitors Regulation Authority
                    . Offices all across London and in major cities in the UK.
                    ©Duncan Lewis >><a href="/about_disclaimer.html">Legal Disclaimer</a>, Copyright & Privacy Policy. Duncan Lewis do not accept service by email.
                </div>
            </div>

</div>
</div>
</body>
<script>
    includeHTML();
</script>
</html>


    
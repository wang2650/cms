﻿using System;
using System.Web.UI.WebControls;
using BaiRong.Core;

namespace SiteServer.BackgroundPages.Account
{
    public class PageProfile : BasePage
    {
        public Literal LtlUserName;
        public TextBox TbDisplayName;
        public TextBox TbEmail;
        public TextBox TbMobile;

        public void Page_Load(object sender, EventArgs e)
        {
            if (IsForbidden) return;

            if (Page.IsPostBack) return;

            LtlUserName.Text = Body.AdministratorInfo.UserName;
            TbDisplayName.Text = Body.AdministratorInfo.DisplayName;
            TbEmail.Text = Body.AdministratorInfo.Email;
            TbMobile.Text = Body.AdministratorInfo.Mobile;
        }

        public void Submit_Click(object sender, EventArgs e)
        {
            if (!Page.IsPostBack || !Page.IsValid) return;

            Body.AdministratorInfo.DisplayName = TbDisplayName.Text;
            Body.AdministratorInfo.Email = TbEmail.Text;
            Body.AdministratorInfo.Mobile = TbMobile.Text;

            BaiRongDataProvider.AdministratorDao.Update(Body.AdministratorInfo);

            SuccessMessage("资料更改成功");
        }
    }
}

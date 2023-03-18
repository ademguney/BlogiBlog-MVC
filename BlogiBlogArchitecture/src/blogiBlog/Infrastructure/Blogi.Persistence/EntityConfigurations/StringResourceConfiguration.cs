namespace Blogi.Persistence.EntityConfigurations
{
	public class StringResourceConfiguration : IEntityTypeConfiguration<StringResource>
	{
		public void Configure(EntityTypeBuilder<StringResource> builder)
		{
			builder.ToTable("StringResources");
			builder.Property(u => u.LanguageId).IsRequired(true);
			builder.Property(u => u.Key).IsRequired(true).HasMaxLength(500);
			builder.Property(u => u.Value).IsRequired(true).HasMaxLength(500);
			builder.HasOne(u => u.Languages);

			builder.HasData(
  new StringResource { Id = 1, LanguageId = 1, Key = "page_language_label_create_new_language", Value = "Yeni Dil Oluştur" }
, new StringResource { Id = 2, LanguageId = 2, Key = "page_language_label_create_new_language", Value = "Create New Language" }
, new StringResource { Id = 3, LanguageId = 1, Key = "page_language_button_delete", Value = "Sil" }
, new StringResource { Id = 4, LanguageId = 2, Key = "page_language_button_delete", Value = "Delete" }
, new StringResource { Id = 5, LanguageId = 1, Key = "page_language_button_update", Value = "Güncelle" }
, new StringResource { Id = 6, LanguageId = 2, Key = "page_language_button_update", Value = "Update" }
, new StringResource { Id = 7, LanguageId = 1, Key = "page_language_label_list", Value = "Dil Listesi" }
, new StringResource { Id = 8, LanguageId = 2, Key = "page_language_label_list", Value = "Language List" }
, new StringResource { Id = 9, LanguageId = 1, Key = "bread_crumb_home", Value = "Ana sayfa" }
, new StringResource { Id = 10, LanguageId = 2, Key = "bread_crumb_home", Value = "Home" }
, new StringResource { Id = 11, LanguageId = 1, Key = "bread_crumb_back_to_home", Value = "Ana sayfaya geri dön" }
, new StringResource { Id = 12, LanguageId = 2, Key = "bread_crumb_back_to_home", Value = "Back to Home" }
, new StringResource { Id = 13, LanguageId = 1, Key = "footer_description", Value = "Blogi Blog" }
, new StringResource { Id = 14, LanguageId = 2, Key = "footer_description", Value = "footer" }
, new StringResource { Id = 15, LanguageId = 1, Key = "datatable_default_label_update", Value = "Güncelle" }
, new StringResource { Id = 16, LanguageId = 2, Key = "datatable_default_label_update", Value = "Update" }
, new StringResource { Id = 17, LanguageId = 1, Key = "page_tag_label_tag_list", Value = "Etiket Listesi" }
, new StringResource { Id = 18, LanguageId = 2, Key = "page_tag_label_tag_list", Value = "Tag List" }
, new StringResource { Id = 19, LanguageId = 1, Key = "page_tag_label_create_new_tag", Value = "Yeni Etiket Oluştur" }
, new StringResource { Id = 20, LanguageId = 2, Key = "page_tag_label_create_new_tag", Value = "Create New Tag" }
, new StringResource { Id = 23, LanguageId = 1, Key = "datatable_default_label_tag_name", Value = "Etiket Adı" }
, new StringResource { Id = 25, LanguageId = 1, Key = "page_default_back_to_list", Value = "Listeye geri dön" }
, new StringResource { Id = 26, LanguageId = 2, Key = "page_default_back_to_list", Value = "Back to List" }
, new StringResource { Id = 27, LanguageId = 1, Key = "page_default_label_home", Value = "Ana sayfa" }
, new StringResource { Id = 28, LanguageId = 2, Key = "page_default_label_home", Value = "Home" }
, new StringResource { Id = 29, LanguageId = 1, Key = "page_tag_label_language", Value = "Dil" }
, new StringResource { Id = 30, LanguageId = 2, Key = "page_default_label_language", Value = "Language" }
, new StringResource { Id = 31, LanguageId = 1, Key = "page_default_label_select_language", Value = "Dil Seçiniz" }
, new StringResource { Id = 32, LanguageId = 2, Key = "page_default_label_select_language", Value = "Select Language" }
, new StringResource { Id = 33, LanguageId = 1, Key = "page_tag_label_tag_name", Value = "Etiket Adı" }
, new StringResource { Id = 34, LanguageId = 2, Key = "page_tag_label_tag_name", Value = "Tag Name" }
, new StringResource { Id = 35, LanguageId = 1, Key = "page_default_button_create", Value = "Kaydet" }
, new StringResource { Id = 36, LanguageId = 2, Key = "page_default_button_create", Value = "Create" }
, new StringResource { Id = 37, LanguageId = 1, Key = "page_default_button_update", Value = "Güncelle" }
, new StringResource { Id = 38, LanguageId = 2, Key = "page_default_button_update", Value = "Update" }
, new StringResource { Id = 39, LanguageId = 1, Key = "page_category_label_category_list", Value = "Kategori Listesi" }
, new StringResource { Id = 40, LanguageId = 2, Key = "page_category_label_category_list", Value = "Category List" }
, new StringResource { Id = 41, LanguageId = 1, Key = "page_category_label_create_new_category", Value = "Yeni Kategori Oluştur" }
, new StringResource { Id = 42, LanguageId = 2, Key = "page_category_label_create_new_category", Value = "Create New Category" }
, new StringResource { Id = 43, LanguageId = 1, Key = "datatable_default_label_language", Value = "Dil" }
, new StringResource { Id = 44, LanguageId = 2, Key = "datatable_default_label_language", Value = "Language" }
, new StringResource { Id = 45, LanguageId = 1, Key = "datatable_default_label_category_name", Value = "Kategori Adı" }
, new StringResource { Id = 46, LanguageId = 2, Key = "datatable_default_label_category_name", Value = "Category Name" }
, new StringResource { Id = 47, LanguageId = 1, Key = "datatable_default_label_description", Value = "Açıklama" }
, new StringResource { Id = 48, LanguageId = 2, Key = "datatable_default_label_description", Value = "Description" }
, new StringResource { Id = 49, LanguageId = 1, Key = "datatable_default_label_slug", Value = "Seo Url" }
, new StringResource { Id = 50, LanguageId = 2, Key = "datatable_default_label_slug", Value = "Slug" }
, new StringResource { Id = 51, LanguageId = 1, Key = "page_category_label_category_name", Value = "Kategori Adı" }
, new StringResource { Id = 52, LanguageId = 2, Key = "page_category_label_category_name", Value = "Category Name" }
, new StringResource { Id = 53, LanguageId = 1, Key = "page_category_label_description", Value = "Açıklama" }
, new StringResource { Id = 54, LanguageId = 2, Key = "page_category_label_description", Value = "Description" }
, new StringResource { Id = 55, LanguageId = 1, Key = "page_default_label_slug", Value = "Seo Url" }
, new StringResource { Id = 56, LanguageId = 2, Key = "datatable_default_label_tag_name", Value = "Tag Name" }
, new StringResource { Id = 57, LanguageId = 1, Key = "datatable_default_label_delete", Value = "Sil" }
, new StringResource { Id = 58, LanguageId = 2, Key = "datatable_default_label_delete", Value = "Delete" }
, new StringResource { Id = 59, LanguageId = 1, Key = "page_default_label_language", Value = "Dil" }
, new StringResource { Id = 60, LanguageId = 2, Key = "page_default_label_slug", Value = "Slug" }
, new StringResource { Id = 61, LanguageId = 1, Key = "page_account_label_show_password", Value = "Şifreyi göster" }
, new StringResource { Id = 62, LanguageId = 2, Key = "page_account_label_show_password", Value = "Show Password" }
, new StringResource { Id = 63, LanguageId = 1, Key = "page_account_label_password", Value = "Parola" }
, new StringResource { Id = 64, LanguageId = 2, Key = "page_account_label_password", Value = "Password" }
, new StringResource { Id = 65, LanguageId = 1, Key = "page_account_label_email", Value = "Email" }
, new StringResource { Id = 66, LanguageId = 2, Key = "page_account_label_email", Value = "Email" }
, new StringResource { Id = 67, LanguageId = 1, Key = "page_account_label_surname", Value = "Soyad" }
, new StringResource { Id = 68, LanguageId = 2, Key = "page_account_label_surname", Value = "Surname" }
, new StringResource { Id = 69, LanguageId = 1, Key = "page_account_label_name", Value = "Ad" }
, new StringResource { Id = 70, LanguageId = 2, Key = "page_account_label_name", Value = "Name" }
, new StringResource { Id = 71, LanguageId = 1, Key = "top_menu_logout", Value = "Çıkış Yap" }
, new StringResource { Id = 72, LanguageId = 2, Key = "top_menu_logout", Value = "Logout" }
, new StringResource { Id = 73, LanguageId = 1, Key = "top_menu_profile", Value = "Hesabım" }
, new StringResource { Id = 74, LanguageId = 2, Key = "top_menu_profile", Value = "Profile" }
, new StringResource { Id = 75, LanguageId = 1, Key = "left_menu_label_blog", Value = "Blog" }
, new StringResource { Id = 76, LanguageId = 2, Key = "left_menu_label_blog", Value = "Blog" }
, new StringResource { Id = 77, LanguageId = 1, Key = "left_menu_label_post", Value = "Makaleler" }
, new StringResource { Id = 78, LanguageId = 2, Key = "left_menu_label_post", Value = "Post" }
, new StringResource { Id = 79, LanguageId = 1, Key = "left_menu_a_default_label_list", Value = "Liste" }
, new StringResource { Id = 80, LanguageId = 2, Key = "left_menu_a_default_label_list", Value = "List" }
, new StringResource { Id = 81, LanguageId = 1, Key = "left_menu_a_default_label_create", Value = "Oluştur" }
, new StringResource { Id = 82, LanguageId = 2, Key = "left_menu_a_default_label_create", Value = "Create" }
, new StringResource { Id = 83, LanguageId = 1, Key = "left_menu_label_mail_setting", Value = "Mail Ayarı" }
, new StringResource { Id = 84, LanguageId = 2, Key = "left_menu_label_mail_setting", Value = "Mail Setting" }
, new StringResource { Id = 85, LanguageId = 1, Key = "left_menu_a_mail_setting_configure", Value = "Yapılandır" }
, new StringResource { Id = 86, LanguageId = 2, Key = "left_menu_a_mail_setting_configure", Value = "Configure" }
, new StringResource { Id = 87, LanguageId = 1, Key = "left_menu_label_string_resource", Value = "Dil Detayları" }
, new StringResource { Id = 88, LanguageId = 2, Key = "left_menu_label_string_resource", Value = "String Resource" }
, new StringResource { Id = 89, LanguageId = 1, Key = "left_menu_label_language", Value = "Dil" }
, new StringResource { Id = 90, LanguageId = 2, Key = "left_menu_label_language", Value = "Language" }
, new StringResource { Id = 91, LanguageId = 1, Key = "left_menu_label_system_config", Value = "Sistem Ayarı" }
, new StringResource { Id = 92, LanguageId = 2, Key = "left_menu_label_system_config", Value = "System Configuration" }
, new StringResource { Id = 93, LanguageId = 1, Key = "left_menu_label_tag", Value = "Etiketler" }
, new StringResource { Id = 94, LanguageId = 2, Key = "left_menu_label_tag", Value = "Tags" }
, new StringResource { Id = 95, LanguageId = 1, Key = "left_menu_label_category", Value = "Kategoriler" }
, new StringResource { Id = 96, LanguageId = 2, Key = "left_menu_label_category", Value = "Categories" }
, new StringResource { Id = 97, LanguageId = 1, Key = "left_menu_label_comment", Value = "Yorumlar" }
, new StringResource { Id = 98, LanguageId = 2, Key = "left_menu_label_comment", Value = "Comments" }
, new StringResource { Id = 99, LanguageId = 1, Key = "page_login_label_welcome", Value = "Blogi Blog'a Hoş Geldiniz" }
, new StringResource { Id = 100, LanguageId = 2, Key = "page_login_label_welcome", Value = "Welcome To Blogi Blog" }
,
	new StringResource { Id = 101, LanguageId = 1, Key = "page_login_label_description", Value = "Blogi Blog açık kaynak kodlu birden fazla dili destekleyen web blog projesidir." }
,
	new StringResource { Id = 102, LanguageId = 2, Key = "page_login_label_description", Value = "Blogi Blog is an open source web blog project that supports multiple languages." }
,
	new StringResource { Id = 103, LanguageId = 1, Key = "page_login_label_login_title", Value = "Hesabınıza giriş yapın" }
,
	new StringResource { Id = 104, LanguageId = 2, Key = "page_login_label_login_title", Value = "Login into your account" }
,
	new StringResource { Id = 105, LanguageId = 1, Key = "page_login_label_keep_me", Value = "Oturumumu açık tut" }
,
	new StringResource { Id = 106, LanguageId = 2, Key = "page_login_label_keep_me", Value = "Keep me logged in" }
,
	new StringResource { Id = 107, LanguageId = 1, Key = "page_login_label_forgot_pass", Value = "Parolanızı mı unuttunuz ?" }
,
	new StringResource { Id = 108, LanguageId = 2, Key = "page_login_label_forgot_pass", Value = "Forgot password ?" }
,
	new StringResource { Id = 109, LanguageId = 1, Key = "page_login_button_login", Value = "Giriş Yap" }
,
	new StringResource { Id = 110, LanguageId = 2, Key = "page_login_button_login", Value = "Login" }
,
	new StringResource { Id = 111, LanguageId = 1, Key = "page_login_label_for_recover_pass", Value = "Şifrenizi kurtarmak için" }
,
	new StringResource { Id = 112, LanguageId = 2, Key = "page_login_label_for_recover_pass", Value = "For recover your password" }
,
	new StringResource { Id = 113, LanguageId = 1, Key = "page_login_button_send_mail", Value = "Bana email gönder" }
,
	new StringResource { Id = 114, LanguageId = 2, Key = "page_login_button_send_mail", Value = "Send me Email" }
,
	new StringResource { Id = 115, LanguageId = 1, Key = "page_mail_setting_label_host", Value = "Host" }
,
	new StringResource { Id = 116, LanguageId = 2, Key = "page_mail_setting_label_host", Value = "Host" }
,
	new StringResource { Id = 117, LanguageId = 1, Key = "page_mail_setting_label_port", Value = "Port" }
,
	new StringResource { Id = 118, LanguageId = 2, Key = "page_mail_setting_label_port", Value = "Port" }
,
	new StringResource { Id = 119, LanguageId = 1, Key = "page_mail_setting_label_full_name", Value = "Ad Soyad" }
,
	new StringResource { Id = 120, LanguageId = 2, Key = "page_mail_setting_label_full_name", Value = "Name Surname" }
,
	new StringResource { Id = 121, LanguageId = 1, Key = "page_mail_setting_label_mail", Value = "Email" }
,
	new StringResource { Id = 122, LanguageId = 2, Key = "page_mail_setting_label_mail", Value = "Email" }
,
	new StringResource { Id = 123, LanguageId = 1, Key = "page_mail_setting_label_password", Value = "Parola" }
,
	new StringResource { Id = 124, LanguageId = 2, Key = "page_mail_setting_label_password", Value = "Password" }
,
	new StringResource { Id = 125, LanguageId = 1, Key = "page_mail_setting_label_show_password", Value = "Parolayı Göster" }
,
	new StringResource { Id = 126, LanguageId = 2, Key = "page_mail_setting_label_show_password", Value = "Show Password" }
,
	new StringResource { Id = 127, LanguageId = 1, Key = "page_mail_setting_label_ssl_enable", Value = "SSL Etkin" }
,
	new StringResource { Id = 128, LanguageId = 2, Key = "page_mail_setting_label_ssl_enable", Value = "SSL Enabled" }
,
	new StringResource { Id = 129, LanguageId = 1, Key = "page_mail_setting_label_use_defaul_credentials", Value = "Varsayılan Kimlik Bilgilerini Kullan" }
,
	new StringResource { Id = 130, LanguageId = 2, Key = "page_mail_setting_label_use_defaul_credentials", Value = "Use Default Credentials" }
,
	new StringResource { Id = 131, LanguageId = 1, Key = "datatable_default_label_culture", Value = "Kod" }
,
	new StringResource { Id = 132, LanguageId = 2, Key = "datatable_default_label_culture", Value = "Culture" }
,
	new StringResource { Id = 133, LanguageId = 1, Key = "page_language_label_culture", Value = "Kod" }
,
	new StringResource { Id = 134, LanguageId = 2, Key = "page_language_label_culture", Value = "Culture" }
,
	new StringResource { Id = 135, LanguageId = 1, Key = "datatable_default_label_title", Value = "Başlık" }
,
	new StringResource { Id = 136, LanguageId = 2, Key = "datatable_default_label_title", Value = "Title" }
,
	new StringResource { Id = 137, LanguageId = 1, Key = "datatable_default_label__display_count", Value = "Görüntülenme Sayısı" }
,
	new StringResource { Id = 138, LanguageId = 2, Key = "datatable_default_label__display_count", Value = "Display Count" }
,
	new StringResource { Id = 139, LanguageId = 1, Key = "datatable_default_label_puslished", Value = "Yayınlandı mı?" }
,
	new StringResource { Id = 140, LanguageId = 2, Key = "datatable_default_label_puslished", Value = "Is Published?" }
,
	new StringResource { Id = 141, LanguageId = 1, Key = "datatable_default_label_creation_date", Value = "Oluşturulma Tarihi" }
,
	new StringResource { Id = 142, LanguageId = 2, Key = "datatable_default_label_creation_date", Value = "Creation Date" }
,
	new StringResource { Id = 143, LanguageId = 1, Key = "datatable_default_label_updation_date", Value = "Güncelleme Tarihi" }
,
	new StringResource { Id = 144, LanguageId = 2, Key = "datatable_default_label_updation_date", Value = "Updation Date" }
,
	new StringResource { Id = 145, LanguageId = 1, Key = "page_post_label_list", Value = "Makale Listesi" }
,
	new StringResource { Id = 146, LanguageId = 2, Key = "page_post_label_list", Value = "Post List" }
,
	new StringResource { Id = 147, LanguageId = 1, Key = "page_post_label_create_new_post", Value = "Yeni Makale Oluştur" }
,
	new StringResource { Id = 148, LanguageId = 2, Key = "page_post_label_create_new_post", Value = "Create New Post" }
,
	new StringResource { Id = 149, LanguageId = 1, Key = "page_post_label_header_image", Value = "Kapak Resmi" }
,
	new StringResource { Id = 150, LanguageId = 2, Key = "page_post_label_header_image", Value = "Header Image" }
,
	new StringResource { Id = 151, LanguageId = 1, Key = "page_post_label_image", Value = "Resim" }
,
	new StringResource { Id = 152, LanguageId = 2, Key = "page_post_label_image", Value = "Image" }
,
	new StringResource { Id = 153, LanguageId = 1, Key = "page_post_label_image_alt", Value = "Resim Açıklaması" }
,
	new StringResource { Id = 154, LanguageId = 2, Key = "page_post_label_image_alt", Value = "Image Alt" }
,
	new StringResource { Id = 155, LanguageId = 1, Key = "page_post_label_seo", Value = "SEO" }
,
	new StringResource { Id = 156, LanguageId = 2, Key = "page_post_label_seo", Value = "SEO" }
,
	new StringResource { Id = 157, LanguageId = 1, Key = "page_post_label_tags", Value = "Etiketler" }
,
	new StringResource { Id = 158, LanguageId = 2, Key = "page_post_label_tags", Value = "Tags" }
,
	new StringResource { Id = 159, LanguageId = 1, Key = "page_post_label_meta_keywords", Value = "Anahtar Kelimeler" }
,
	new StringResource { Id = 160, LanguageId = 2, Key = "page_post_label_meta_keywords", Value = "Meta Keywords" }
,
	new StringResource { Id = 161, LanguageId = 1, Key = "page_post_label_meta_description", Value = "Meta Açıklaması" }
,
	new StringResource { Id = 162, LanguageId = 2, Key = "page_post_label_meta_description", Value = "Meta Description" }
,
	new StringResource { Id = 163, LanguageId = 1, Key = "page_post_label_url", Value = "Seo Url" }
,
	new StringResource { Id = 164, LanguageId = 2, Key = "page_post_label_url", Value = "Slug" }
,
	new StringResource { Id = 165, LanguageId = 1, Key = "page_post_label_post", Value = "MAKALE" }
,
	new StringResource { Id = 166, LanguageId = 2, Key = "page_post_label_post", Value = "POST" }
,
	new StringResource { Id = 167, LanguageId = 1, Key = "page_default_label_category", Value = "Kategori" }
,
	new StringResource { Id = 168, LanguageId = 2, Key = "page_default_label_category", Value = "Category" }
,
	new StringResource { Id = 169, LanguageId = 1, Key = "page_default_label_select_category", Value = "Kategori Seç" }
,
	new StringResource { Id = 170, LanguageId = 2, Key = "page_default_label_select_category", Value = "Select Category" }
,
	new StringResource { Id = 171, LanguageId = 1, Key = "page_post_label_title", Value = "Makale Başlığı" }
,
	new StringResource { Id = 172, LanguageId = 2, Key = "page_post_label_title", Value = "Post Title" }
,
	new StringResource { Id = 173, LanguageId = 1, Key = "page_post_label_is_published", Value = "Yayınlansın mı?" }
,
	new StringResource { Id = 174, LanguageId = 2, Key = "page_post_label_is_published", Value = "Is Published?" }
,
	new StringResource { Id = 175, LanguageId = 1, Key = "datatable_default_label_answer", Value = "Cevapla" }
,
	new StringResource { Id = 176, LanguageId = 2, Key = "datatable_default_label_answer", Value = "Answer" }
,
	new StringResource { Id = 177, LanguageId = 1, Key = "datatable_default_label_email", Value = "Email" }
,
	new StringResource { Id = 178, LanguageId = 2, Key = "datatable_default_label_email", Value = "Email" }
,
	new StringResource { Id = 179, LanguageId = 1, Key = "datatable_default_label_name_surname", Value = "Ad Soyad" }
,
	new StringResource { Id = 180, LanguageId = 2, Key = "datatable_default_label_name_surname", Value = "Name Surname" }
,
	new StringResource { Id = 181, LanguageId = 1, Key = "page_comment_label_list", Value = "Yorum Listesi" }
,
	new StringResource { Id = 182, LanguageId = 2, Key = "page_comment_label_list", Value = "Comment List" }
,
	new StringResource { Id = 183, LanguageId = 1, Key = "blog_ui_navbar_home", Value = "Anasayfa" }
,
	new StringResource { Id = 184, LanguageId = 2, Key = "blog_ui_navbar_home", Value = "Home" }
,
	new StringResource { Id = 185, LanguageId = 1, Key = "blog_ui_navbar_about", Value = "Hakkımda" }
,
	new StringResource { Id = 186, LanguageId = 2, Key = "blog_ui_navbar_about", Value = "About" }
,
	new StringResource { Id = 187, LanguageId = 1, Key = "blog_ui_navbar_contact", Value = "İletişim" }
,
	new StringResource { Id = 188, LanguageId = 2, Key = "blog_ui_navbar_contact", Value = "Contact" }
,
	new StringResource { Id = 189, LanguageId = 1, Key = "blog_ui_category", Value = "Kategoriler" }
,
	new StringResource { Id = 190, LanguageId = 2, Key = "blog_ui_category", Value = "Category" }
,
	new StringResource { Id = 191, LanguageId = 1, Key = "blog_ui_popular_tags", Value = "Popüler Etiketler" }
,
	new StringResource { Id = 192, LanguageId = 2, Key = "blog_ui_popular_tags", Value = "Popular Tags" }
,
	new StringResource { Id = 193, LanguageId = 1, Key = "blog_ui_place_holder_search", Value = "Arama..." }
,
	new StringResource { Id = 194, LanguageId = 2, Key = "blog_ui_place_holder_search", Value = "Search..." }
,
	new StringResource { Id = 195, LanguageId = 1, Key = "blog_ui_articles", Value = "Makaleler" }
,
	new StringResource { Id = 196, LanguageId = 2, Key = "blog_ui_articles", Value = "Articles" }
,
	new StringResource { Id = 197, LanguageId = 1, Key = "blog_ui_blog_and_news", Value = "Blog & Makaleler" }
,
	new StringResource { Id = 198, LanguageId = 2, Key = "blog_ui_blog_and_news", Value = "Blog & News" }
,
	new StringResource { Id = 199, LanguageId = 1, Key = "blog_ui_follow_us", Value = "Bizi takip edin" }
,
	new StringResource { Id = 200, LanguageId = 2, Key = "blog_ui_follow_us", Value = "Follow Us" }
,
	new StringResource { Id = 201, LanguageId = 1, Key = "blog_ui_footer_title", Value = "Açık Kaynak, Birden Fazla Dil Destekleyen Blog Projesi" }
,
	new StringResource { Id = 202, LanguageId = 2, Key = "blog_ui_footer_title", Value = " an Open Source Multi Language Blog Project" }
,
	new StringResource { Id = 203, LanguageId = 1, Key = "blog_ui_contact_information", Value = "İletişim Bilgileri" }
,
	new StringResource { Id = 204, LanguageId = 2, Key = "blog_ui_contact_information", Value = "Contact information" }
,
	new StringResource { Id = 205, LanguageId = 1, Key = "blog_ui_contact_phone", Value = "Tel" }
,
	new StringResource { Id = 206, LanguageId = 2, Key = "blog_ui_contact_phone", Value = "Phone" }
,
	new StringResource { Id = 207, LanguageId = 1, Key = "blog_ui_contact_email", Value = "Email" }
,
	new StringResource { Id = 208, LanguageId = 2, Key = "blog_ui_contact_email", Value = "Email" }
,
	new StringResource { Id = 209, LanguageId = 1, Key = "blog_ui_contact_form", Value = "İletişim formu" }
,
	new StringResource { Id = 210, LanguageId = 2, Key = "blog_ui_contact_form", Value = "Contact form" }
,
	new StringResource { Id = 211, LanguageId = 1, Key = "blog_ui_contact_description", Value = "E-posta hesabınız yayımlanmayacak. Gerekli alanlar işaretlendi *" }
,
	new StringResource { Id = 212, LanguageId = 2, Key = "blog_ui_contact_description", Value = "Your email address will not be published. Required fields are marked *" }
,
	new StringResource { Id = 213, LanguageId = 1, Key = "left_menu_label_pages", Value = "Sayfalar" }
,
	new StringResource { Id = 214, LanguageId = 2, Key = "left_menu_label_pages", Value = "Pages" }
,
	new StringResource { Id = 215, LanguageId = 1, Key = "left_menu_label_about", Value = "Hakkımda" }
,
	new StringResource { Id = 216, LanguageId = 2, Key = "left_menu_label_about", Value = "About" }
,
	new StringResource { Id = 217, LanguageId = 1, Key = "left_menu_label_contact", Value = "İletişim" }
,
	new StringResource { Id = 218, LanguageId = 2, Key = "left_menu_label_contact", Value = "Contact" }
,
	new StringResource { Id = 219, LanguageId = 1, Key = "left_menu_label_web_settings", Value = "Web Ayarı" }
,
	new StringResource { Id = 220, LanguageId = 2, Key = "left_menu_label_web_settings", Value = "Web Setting" }
,
	new StringResource { Id = 221, LanguageId = 1, Key = "page_web_setting_label_show_linkedin", Value = "Linkedin Gösterilsin mi?" }
,
	new StringResource { Id = 222, LanguageId = 2, Key = "page_web_setting_label_show_linkedin", Value = "Show Linkedin" }
,
	new StringResource { Id = 223, LanguageId = 1, Key = "page_web_setting_label_show_github", Value = "Github Gösterilsin mi?" }
,
	new StringResource { Id = 224, LanguageId = 2, Key = "page_web_setting_label_show_github", Value = "Show Github?" }
,
	new StringResource { Id = 225, LanguageId = 1, Key = "page_web_setting_label_show_medium", Value = "Medium Gösterilsin mi?" }
,
	new StringResource { Id = 226, LanguageId = 2, Key = "page_web_setting_label_show_medium", Value = "Show Medium?" }
,
	new StringResource { Id = 227, LanguageId = 1, Key = "page_web_setting_label_show_youtube", Value = "YouTube Gösterilsin mi?" }
,
	new StringResource { Id = 228, LanguageId = 2, Key = "page_web_setting_label_show_youtube", Value = "Show YouTube?" }
,
	new StringResource { Id = 229, LanguageId = 1, Key = "page_web_setting_label_show_instagram", Value = "Instagram Gösterilsin mi?" }
,
	new StringResource { Id = 230, LanguageId = 2, Key = "page_web_setting_label_show_instagram", Value = "Show Instagram?" }
,
	new StringResource { Id = 231, LanguageId = 1, Key = "page_web_setting_label_show_twitter", Value = "Twitter Gösterilsin mi?" }
,
	new StringResource { Id = 232, LanguageId = 2, Key = "page_web_setting_label_show_twitter", Value = "Show Twitter" }
,
	new StringResource { Id = 233, LanguageId = 1, Key = "page_web_setting_label_show_facebook", Value = "Facebook Gösterilsin mi?" }
,
	new StringResource { Id = 234, LanguageId = 2, Key = "page_web_setting_label_show_facebook", Value = "Show Facebook?" }
,
	new StringResource { Id = 235, LanguageId = 1, Key = "page_web_setting_label_social_site_link", Value = "Sosyal Site Bağlantıları" }
,
	new StringResource { Id = 236, LanguageId = 2, Key = "page_web_setting_label_social_site_link", Value = "Social Site Links" }
,
	new StringResource { Id = 237, LanguageId = 1, Key = "page_web_setting_label_meta_configuration", Value = "Meta Yapılandırılmısı" }
,
	new StringResource { Id = 238, LanguageId = 2, Key = "page_web_setting_label_meta_configuration", Value = "Meta Configuration" }
,
	new StringResource { Id = 239, LanguageId = 1, Key = "page_web_setting_label_meta_description", Value = "Meta Açıklaması" }
,
	new StringResource { Id = 240, LanguageId = 2, Key = "page_web_setting_label_meta_description", Value = "Meta Description" }
,
	new StringResource { Id = 241, LanguageId = 1, Key = "page_web_setting_label_meta_keywords", Value = "Anahtar Kelimeler" }
,
	new StringResource { Id = 242, LanguageId = 2, Key = "page_web_setting_label_meta_keywords", Value = "Meta Keywords" }
,
	new StringResource { Id = 243, LanguageId = 1, Key = "page_web_setting_label_author", Value = "Yazar" }
,
	new StringResource { Id = 244, LanguageId = 2, Key = "page_web_setting_label_author", Value = "Author" }
,
	new StringResource { Id = 245, LanguageId = 1, Key = "page_web_setting_label_title", Value = "Başlık" }
,
	new StringResource { Id = 246, LanguageId = 2, Key = "page_web_setting_label_title", Value = "Title" }
,
	new StringResource { Id = 247, LanguageId = 1, Key = "page_contact_label_phone", Value = "Telefon" }
,
	new StringResource { Id = 248, LanguageId = 2, Key = "page_contact_label_phone", Value = "Phone" }
,
	new StringResource { Id = 249, LanguageId = 1, Key = "page_contact_label_location", Value = "Lokasyon" }
,
	new StringResource { Id = 250, LanguageId = 2, Key = "page_contact_label_location", Value = "Location" }
,
	new StringResource { Id = 251, LanguageId = 1, Key = "blog_ui_post_leave_comment", Value = "Yorum Yap" }
,
	new StringResource { Id = 252, LanguageId = 2, Key = "blog_ui_post_leave_comment", Value = "Leave a Comment" }
,
	new StringResource { Id = 253, LanguageId = 1, Key = "blog_ui_post_write_comment", Value = "Yorum Yaz..." }
,
	new StringResource { Id = 254, LanguageId = 2, Key = "blog_ui_post_write_comment", Value = "Write Comment..." }
,
	new StringResource { Id = 255, LanguageId = 1, Key = "blog_ui_post_name_surname", Value = "Ad Soyad" }
,
	new StringResource { Id = 256, LanguageId = 2, Key = "blog_ui_post_name_surname", Value = "Name Surname" }
,
	new StringResource { Id = 257, LanguageId = 1, Key = "blog_ui_post_email", Value = "Email" }
,
	new StringResource { Id = 258, LanguageId = 2, Key = "blog_ui_post_email", Value = "Email" }
,
	new StringResource { Id = 259, LanguageId = 1, Key = "blog_ui_post_post_comment", Value = "Yorumu Gönder" }
,
	new StringResource { Id = 260, LanguageId = 2, Key = "blog_ui_post_post_comment", Value = "Post Comment" }
,
	new StringResource { Id = 261, LanguageId = 1, Key = "blog_ui_post_comments", Value = "Yorumlar" }
,
	new StringResource { Id = 262, LanguageId = 2, Key = "blog_ui_post_comments", Value = "Comments" }
,
	new StringResource { Id = 263, LanguageId = 1, Key = "blog_ui_articles_count_comment", Value = "Yorum" }
,
	new StringResource { Id = 264, LanguageId = 2, Key = "blog_ui_articles_count_comment", Value = "Comments" }
,
	new StringResource { Id = 265, LanguageId = 1, Key = "blog_ui_articles_count_view", Value = "Görüntülenme" }
,
	new StringResource { Id = 266, LanguageId = 2, Key = "blog_ui_articles_count_view", Value = "Views" }
,
	new StringResource { Id = 267, LanguageId = 1, Key = "blog_ui_contact_send_message", Value = "Mesajı Gönder" }
,
	new StringResource { Id = 268, LanguageId = 2, Key = "blog_ui_contact_send_message", Value = "Send Message" }
,
	new StringResource { Id = 269, LanguageId = 1, Key = "blog_ui_post_reply", Value = "Cevapla" }
,
	new StringResource { Id = 270, LanguageId = 2, Key = "blog_ui_post_reply", Value = "Reply" }

	,
	new StringResource { Id = 271, LanguageId = 1, Key = "page_home_label_read_article", Value = "Bu yıl en çok okunan 10 makale." },
	new StringResource { Id = 272, LanguageId = 2, Key = "page_home_label_read_article", Value = "Top 10 most read articles this year." },
	new StringResource { Id = 273, LanguageId = 1, Key = "page_home_label_count_of_tag", Value = "Etiket Sayısı" },
	new StringResource { Id = 274, LanguageId = 2, Key = "page_home_label_count_of_tag", Value = "Count of Tag" },
	new StringResource { Id = 275, LanguageId = 1, Key = "page_home_label_count_of_comment", Value = "Yorum Sayısı" },
	new StringResource { Id = 276, LanguageId = 2, Key = "page_home_label_count_of_comment", Value = "Count of Comment" },
	new StringResource { Id = 277, LanguageId = 1, Key = "page_home_label_count_of_category", Value = "Kategori Sayısı" },
	new StringResource { Id = 278, LanguageId = 2, Key = "page_home_label_count_of_category", Value = "Count of Category" },
	new StringResource { Id = 279, LanguageId = 1, Key = "page_home_label_count_of_article", Value = "Makale Sayısı" },
	new StringResource { Id = 280, LanguageId = 2, Key = "page_home_label_count_of_article", Value = "Count of Article" }

		 );
		}
	}
}

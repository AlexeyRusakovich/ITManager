use ITManager;

insert into [User] values ('admin', 'admin', '1998-02-27', 14, 'admin', '9+pjxTUxE8NdpZ8g5Ei7oy9mDaniMWXhMtmxdtRzPvkyXj4oqzMe7NBtlxWMRq8NdBOgfeZpagGuzKWytFgEXxbrZuzmCeF/BB+Bz5Kkr0EVQ/nIH7gl6crxW1crOhXaj2z2Rp2dmz07+z7Mf2uiJPbY6aGBhyswHkoSvKIbjsM=', 'MKRLzk0M3S2eZHCShoaprRyK0i+Vmryc', 0, null);

begin
	DECLARE @adminId int;
	set @adminId = (select Id from [User] u where u.Login = 'admin');
	insert into [UserRoles] values (@adminId, 1);
end
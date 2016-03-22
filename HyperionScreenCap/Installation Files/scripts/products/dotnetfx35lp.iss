[CustomMessages]


;http://www.microsoft.com/globaldev/reference/lcid-all.mspx


[Code]
procedure dotnetfx35lp();
begin
	if (ActiveLanguage() <> 'en') then begin
		if (not netfxinstalled(NetFx35, CustomMessage('dotnetfx35lp_lcid'))) then
			AddProduct('dotnetfx35_' + ActiveLanguage() + '.exe',
				'/lang:enu /passive /norestart',
				CustomMessage('dotnetfx35lp_title'),
				CustomMessage('dotnetfx35lp_size'),
				CustomMessage('dotnetfx35lp_url'),
				false, false, false);
	end;
end;

[Setup]

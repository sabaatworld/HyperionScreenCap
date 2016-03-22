; http://www.microsoft.com/downloads/details.aspx?familyid=92E0E1CE-8693-4480-84FA-7D85EEF59016

[CustomMessages]


;http://www.microsoft.com/globaldev/reference/lcid-all.mspx


[Code]
procedure dotnetfx20lp();
begin
	if (ActiveLanguage() <> 'en') then begin
		if (not netfxinstalled(NetFx20, CustomMessage('dotnetfx20lp_lcid'))) then
			AddProduct('dotnetfx20' + GetArchitectureString() + '_' + ActiveLanguage() + '.exe',
				'/passive /norestart /lang:ENU',
				CustomMessage('dotnetfx20lp_title'),
				CustomMessage('dotnetfx20lp_size'),
				CustomMessage('dotnetfx20lp_url' + GetArchitectureString()),
				false, false, false);
	end;
end;

[Setup]

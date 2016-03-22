; http://www.microsoft.com/downloads/details.aspx?FamilyID=c69789e0-a4fa-4b2e-a6b5-3b3695825992

[CustomMessages]


;http://www.microsoft.com/globaldev/reference/lcid-all.mspx


[Code]
procedure dotnetfx20sp2lp();
begin
	if (ActiveLanguage() <> 'en') then begin
		if (netfxspversion(NetFx20, CustomMessage('dotnetfx20sp2lp_lcid')) < 2) then
			AddProduct('dotnetfx20sp2' + GetArchitectureString() + '_' + ActiveLanguage() + '.exe',
				'/lang:enu /passive /norestart"',
				CustomMessage('dotnetfx20sp2lp_title'),
				CustomMessage('dotnetfx20sp2lp_size'),
				CustomMessage('dotnetfx20sp2lp_url' + GetArchitectureString()),
				false, false, false);
	end;
end;

[Setup]

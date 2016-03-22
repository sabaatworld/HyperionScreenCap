; http://www.microsoft.com/downloads/details.aspx?FamilyID=1cc39ffe-a2aa-4548-91b3-855a2de99304

[CustomMessages]


;http://www.microsoft.com/globaldev/reference/lcid-all.mspx


[Code]
procedure dotnetfx20sp1lp();
begin
	if (ActiveLanguage() <> 'en') then begin
		if (netfxspversion(NetFx20, CustomMessage('dotnetfx20sp1lp_lcid')) < 1) then
			AddProduct('dotnetfx20sp1' + GetArchitectureString() + '_' + ActiveLanguage() + '.exe',
				'/passive /norestart /lang:ENU',
				CustomMessage('dotnetfx20sp1lp_title'),
				CustomMessage('dotnetfx20sp1lp_size'),
				CustomMessage('dotnetfx20sp1lp_url' + GetArchitectureString()),
				false, false, false);
	end;
end;

[Setup]

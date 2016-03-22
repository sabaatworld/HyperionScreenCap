[CustomMessages]


;http://www.microsoft.com/globaldev/reference/lcid-all.mspx


[Code]
procedure dotnetfx11lp();
begin
	if (ActiveLanguage() <> 'en') then begin
		if (IsX86() and not netfxinstalled(NetFx11, CustomMessage('dotnetfx11lp_lcid'))) then
			AddProduct('dotnetfx11' + ActiveLanguage() + '.exe',
				'/q:a /c:"inst.exe /qb /l"',
				CustomMessage('dotnetfx11lp_title'),
				CustomMessage('dotnetfx11lp_size'),
				CustomMessage('dotnetfx11lp_url'),
				false, false, false);
	end;
end;

[Setup]

echo off
curl -v -b cookie -X PUT -F "space_template[zip]=@D:\GitHub\Italy\Italian Village\template.zip" -F "space_template[game_engine_version]=20194" https://account.altvr.com/api/space_templates/1589836115920028304.json

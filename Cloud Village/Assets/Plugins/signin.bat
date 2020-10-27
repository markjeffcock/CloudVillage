echo off
title Sign In to AltspaceVR
curl -v -d "user[email]=mark.jeffcock@gmail.com&user[password]=Whatwhy72" https://account.altvr.com/users/sign_in.json -c cookie

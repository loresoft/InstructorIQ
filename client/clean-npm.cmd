@echo off

rmdir "node_modules" /S /Q
del package-lock.json
npm cache verify

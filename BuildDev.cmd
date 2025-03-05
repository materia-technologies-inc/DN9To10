set wireit_logger=simple
set wireit_parallel=1
call pnpm build
taskkill /f /im "node.exe"

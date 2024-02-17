curl -fsSL https://packages.microsoft.com/keys/microsoft.asc | sudo gpg --dearmor -o /usr/share/keyrings/microsoft-prod.gpg

curl https://packages.microsoft.com/keys/microsoft.asc | sudo tee /etc/apt/trusted.gpg.d/microsoft.asc

curl -fsSL https://packages.microsoft.com/config/ubuntu/22.04/mssql-server-2022.list | sudo tee /etc/apt/sources.list.d/mssql-server-2022.list

sudo apt update

sudo apt install -y mssql-server

sudo /opt/mssql/bin/mssql-conf setup

sudo systemctl status mssql-server --no-pager

# start service
sudo systemctl start mssql-server

# enable service
sudo systemctl enable mssql-server

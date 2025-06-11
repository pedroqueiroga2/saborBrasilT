

# Tutorial Acess by ip

## 1 - Abra o CMD e digite "ipconfig", isso lhe retornará essa tela:


### copie somente o "IPv4".


## 2 - abrir o Powershell como Administrador e executar o seguinte comando:

#### netsh advfirewall firewall add rule name="ASP.NET Core" dir=in action=allo protocol=TCP localport=5172

Esse comando cria uma regra de entrada no firewall do Windows, permitindo conexões TCP vindas de fora para a porta 5172, onde está rodando a aplicação ASP.NET Core.

## 3 - Execute o servidor

![image](https://github.com/user-attachments/assets/400db568-4ee2-4807-b4df-00c5ba9a502b)

## 4 - Adicione o endereço do site

### O endereço é o ip do seu pc (Ipv4) + a porta 5172.

exemplo:

0.0.0.0:5172





# CondominioDev
Modulo2-ProjetodeRecuperacao

1 INTRODUÇÃO
Construir uma API .Net.
Uma API 100% funcional, uma API de cadastro do Condomínio Dev.

2 REQUISITOS DA APLICAÇÃO
A aplicação deverá ser realizada individualmente, necessitando contemplar os seguintes
requisitos:
● Utilização do conceito de GitFlow e organização dos commits
● Criação da modelagem de dados (conceitual, lógica BrModelo (ou outro software) e
física)
● Cadastro de habitante
● Listagem de habitantes
● Detalhamento de habitante através do ID (listar todos os dados menos o ID)
● Deleção de habitante
● Listagem de habitante por regra:
1
○ Apenas habitantes com idade igual ou superior a X anos
● Geração de relatório financeiro

3 ROTEIRO DA APLICAÇÃO
● Organização Git:
○ Utilização do padrão baseado em GitFlow com branches master/main, features e
releases
○ Utilização de commits curtos e concisos
● Requisito geral da aplicação:
○ Utilização de C# com .Net, Git com GitHub e SQL Server
● Listar os habitantes do condomínio:
○ Listar todos os habitantes
○ Listar os habitantes por nome
○ Listar os habitantes por data de nascimento trazendo pelo mês
■ Exemplo: Todos nascidos no mês de Maio
○ Em todos os casos acima, retornar o nome e o ID de cada um dos habitantes
● Listar apenas habitantes com idade igual ou superior a X anos:
○ Retornar apenas os habitantes com idade igual ou superior a X anos
○ O valor de X terá que ser passado como parâmetro da rota
● Cadastro de Habitantes:
○ Não permitir cadastro duplicado
○ Não permitir cadastro com valores inválidos para o habitante
○ Um habitante deve conter: ID, nome, sobrenome, data de nascimento, renda e
CPF
● Detalhamento de um habitante:
○ Trazer pelo ID do habitante
○ Retornar na rota todos os atributos de um habitante menos o seu ID
● Deletar um habitante:
○ Implementar deleção total (não é a deleção lógica)
○ Através do ID do habitante deletar ele do banco
● Criar modelagem de dados do condomínio:
○ Modelagem conceitual
■ Exportar esboço do modelo seguido das entidades
○ Modelagem Lógica
■ Exportar PDF ou PNG do BrModelo (Apenas o Diagrama)
○ Modelagem Física
■ Exportar arquivo sql ou editor de texto com a modelagem SQL
2
● Gerar relatório financeiro do condomínio:
○ O relatório deverá conter os seguintes atributos:
■ A diferença entre o orçamento do condomínio com o gasto total do
mesmo
■ O gasto total do condomínio:
● O somatório da renda de todos os habitantes
■ O orçamento do condomínio
■ O morador com o maior custo do condomínio

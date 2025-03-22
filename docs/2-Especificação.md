# Especificações do Projeto




Nessa parte do documento sera abordado técnicas e modelos que auxiliam na organização para a fundação da EASYHost.

## Personas

User Personas

1. Givanildo Barbosa, 38 anos, Gerente de Hotel
 
Givanildo tem 38 anos e gerencia um hotel boutique em uma cidade turística. Seu cotidiano em relação a seu serviço envolve organizar a equipe de limpeza para garantir que os quartos estejam prontos para os hóspedes e coordenar a equipe da recepção. Givanildo precisa de uma ferramenta para facilitar na alocação dos quartos e no gerenciamento de serviço de quarto. Como trabalha com uma equipe pequena, precisa de um sistema intuitivo que reduza o tempo gasto com atividades manuais e aumente a eficiência do seu trabalho.

2. Max Verstappen, 27 anos, Dono de Hotel/Pousada

Max tem 27 anos e é proprietário de uma pousada que herdou de sua familia. Max tem uma visão mais estratégica em relação a sua pousada e quer acompanhar os custos operacionais do hotel sem perder tempo com tarefas simples do dia a dia. A sua maior preocupação é conseguir manter os lucros do négocio, garantindo que a equipe esteja bem gerida e com maior facilidade de visualizar a folha de pagamento e o orçamento. Ele prefere não usar sistemas muito complexos e prefere algo que ofereça uma gestão fácil e intuitiva.

3. Larissa Santos, 32 anos, Coordenadora do departamento de serviço de quarto de Hotel

Larissa tem 32 anos e é responsável por coordenar a equipe de limpeza e manutenção do hotel. Seu trabalho envolve garantir que os quartos estejam sempre prontos e que os serviços de quarto sejam realizados no prazo ou a pedido do hóspede. Larissa precisa de uma ferramenta que permita visualizar facilmente quais quartos precisam de limpeza, quais funcionários estão disponíveis para realizar essa limpeza e de um jeito mais facil de organizar a equipe para trabalhar de forma eficiente.




## Histórias de Usuários

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE`                                                                           |PARA ... `MOTIVO/VALOR`                                              |
|--------------------|--------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------|
|Givanildo Barbosa   | Gerenciamento de alocação de quartos                                                                         | Reduzir tempo gasto manualmente e melhorar a eficiência do hotel    |
|Givanildo Barbosa   | Gerenciamento de serviço de quarto                                                                           | Reduzir tempo gasto manualmente e melhorar a eficiência do hotel    |
|Max Verstappen      | Ferramenta para garantir boa gestão da equipe                                                                | Acompanhar as equipes e custos oepracionais do hotel com eficiência |
|Max Verstappen      | Ferramenta para visualizar a folha de pagamento de forma mais prática                                        | Acompanhar as equipes e custos oepracionais do hotel com eficiência |
|Larissa Santos      | Método que permita visualizar os quartos com necessidade de limpeza e alocação de funcionários a esse quarto | Organizar a equipe de forma rápida e prática                        |





## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto. Para determinar a prioridade de requisitos, aplicar uma técnica de priorização de requisitos e detalhar como a técnica foi aplicada.

*NOSSOS REQUISITOS*
### Requisitos Funcionais

|ID    | Descrição do Requisito               | Prioridade |
|------|--------------------------------------|------|
|RF-001| Cadastro de hotel para gerenciamento | ALTA | 
|RF-002| Alocação de hóspedes em quartos      | ALTA |
|RF-003| Menu de serviços de quartos          | MÉDIO |
|RF-004| Gerenciamento de folha salarial      | ALTA |
|RF-005| Cadastro de funcionários             | ALTA |
|RF-006| Controle de materiais de uso e consumo| BAIXA |


### Requisitos não Funcionais

|ID     | Descrição do Requisito                                        |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser responsivo para rodar em um dispositivos móvel | MÉDIA | 
|RNF-002| Deve processar requisições do usuário em no máximo 3s |  BAIXA | 
|RNF-003| Gerar relatório de hospedagens anuais, mensais e semanais |  BAIXA | 
|RNF-004| Gerar relatório de serviços anuais, mensais e semanais |  BAIXA | 



## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


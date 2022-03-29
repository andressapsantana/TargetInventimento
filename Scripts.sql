CREATE TABLE PESSOA(


	 IDPESSOA       INTEGER                    IDENTITY(1,1),
     NOMECOMPLETO       NVARCHAR(150)              NOT NULL,
     DATANASCIMENTO     DATETIME                   NOT NULL,
     CPF                NVARCHAR(11)               NOT NULL,
     RENDAMENSAL        DECIMAL(18, 2)             NOT NULL,
     PRIMARY KEY(IDPESSOA))

GO

CREATE TABLE ENDERECO(

     IDENDERECO         INTEGER                IDENTITY(1,1),
     LOGRADOURO             NVARCHAR(120)              NOT NULL,
     BAIRRO                 NVARCHAR(80)               NOT NULL,
     CEP                    NVARCHAR(8)                NOT NULL,
     CIDADE                 NVARCHAR(30)               NOT NULL,
     UF                     NVARCHAR(2)                NOT NULL,
     COMPLEMENTO            NVARCHAR(50)               NOT NULL,
     IDPESSOA               INTEGER                    NOT NULL,
     PRIMARY KEY(IDENDERECO),
     FOREIGN KEY(IDPESSOA)
        REFERENCES PESSOA(IDPESSOA))

GO



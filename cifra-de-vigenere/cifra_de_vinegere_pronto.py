#@auth = Pedro Grachet

frase_processada = ""
alfabeto = ['a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z']
tipo = int(input("Modo\n1 - Criptografar\n2 - Descriptografar\nSua Opção: "))
frase = ''.join(str(input("Digite a frase: ")).lower().split())
chave = str(input("Digite a chave: ")).lower()
chave_processada = ""
if(len(chave)>len(frase)):
    print("A chave é maior que a frase! Tente novamente.")
else:
    i = int(0)
    while (len(chave_processada)<len(frase)):
        chave_processada += chave[i]
        i+=1
        if(i == len(chave)):
            i = 0

    for i in range(len(frase)):
        if(frase[i]) != ' ':
            index_letra_frase = int(alfabeto.index(frase[i]))
            index_letra_chave = int(alfabeto.index(chave_processada[i]))
            if(tipo == 1):
                frase_processada += str(alfabeto[(index_letra_frase+index_letra_chave) % len(alfabeto)])
            else:
                frase_processada += str(alfabeto[(index_letra_frase-index_letra_chave) % len(alfabeto)])
        else:
            frase_processada += ' '
    print("Frase processada: {}".format(frase_processada))

    #atualizando
str='criSdmetio1AUdW9dP3n----'
count=0
str1=''
for i in range(5): 
    for j in range(len(str)):
        if (count%5==0):
            if str[j]=='0':
                str1=str1+'-'
            else:
                str1=str1+str[j]
        count+=1

print (str1)



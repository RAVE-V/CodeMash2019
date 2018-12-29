f=open('ascii.txt','r')
for line in f.readlines():
    line.strip('\r').strip('\n')
    print('****')
    print(line.replace('#',''))

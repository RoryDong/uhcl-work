/**********************************************************************/
/*   ____  ____                                                       */
/*  /   /\/   /                                                       */
/* /___/  \  /                                                        */
/* \   \   \/                                                       */
/*  \   \        Copyright (c) 2003-2009 Xilinx, Inc.                */
/*  /   /          All Right Reserved.                                 */
/* /---/   /\                                                         */
/* \   \  /  \                                                      */
/*  \___\/\___\                                                    */
/***********************************************************************/

/* This file is designed for use with ISim build 0x7708f090 */

#define XSI_HIDE_SYMBOL_SPEC true
#include "xsi.h"
#include <memory.h>
#ifdef __GNUC__
#include <stdlib.h>
#else
#include <malloc.h>
#define alloca _alloca
#endif
static const char *ng0 = "C:/Users/bakerw3779/FourBitALU/FourBitALU.vhd";
extern char *IEEE_P_1242562249;
extern char *IEEE_P_2592010699;

char *ieee_p_1242562249_sub_1547198987_1035706684(char *, char *, char *, char *, char *, char *);
char *ieee_p_1242562249_sub_1919365254_1035706684(char *, char *, char *, char *, int );
char *ieee_p_1242562249_sub_1919437128_1035706684(char *, char *, char *, char *, int );
char *ieee_p_1242562249_sub_2540846514_1035706684(char *, char *, char *, char *, int );
char *ieee_p_1242562249_sub_2547962040_1035706684(char *, char *, char *, char *, int );
char *ieee_p_2592010699_sub_1697423399_503743352(char *, char *, char *, char *, char *, char *);
char *ieee_p_2592010699_sub_1735675855_503743352(char *, char *, char *, char *, char *, char *);
char *ieee_p_2592010699_sub_795620321_503743352(char *, char *, char *, char *, char *, char *);


static void work_a_2908362313_3212880686_p_0(char *t0)
{
    char t41[16];
    char t42[16];
    char t43[16];
    char t48[16];
    char *t1;
    char *t2;
    char *t3;
    char *t4;
    char *t5;
    int t6;
    int t7;
    char *t8;
    char *t9;
    int t10;
    char *t11;
    char *t12;
    int t13;
    char *t14;
    char *t15;
    int t16;
    char *t17;
    char *t18;
    int t19;
    char *t20;
    char *t21;
    int t22;
    char *t23;
    int t25;
    char *t26;
    int t28;
    char *t29;
    int t31;
    char *t32;
    int t34;
    char *t35;
    char *t36;
    char *t37;
    char *t38;
    char *t39;
    char *t40;
    unsigned int t44;
    unsigned int t45;
    unsigned int t46;
    unsigned char t47;

LAB0:    xsi_set_current_line(52, ng0);
    t1 = (t0 + 3552);
    t2 = (t1 + 56U);
    t3 = *((char **)t2);
    t4 = (t3 + 56U);
    t5 = *((char **)t4);
    *((unsigned char *)t5) = (unsigned char)2;
    xsi_driver_first_trans_fast_port(t1);
    xsi_set_current_line(53, ng0);
    t1 = (t0 + 1352U);
    t2 = *((char **)t1);
    t1 = (t0 + 5646);
    t6 = xsi_mem_cmp(t1, t2, 4U);
    if (t6 == 1)
        goto LAB3;

LAB15:    t4 = (t0 + 5650);
    t7 = xsi_mem_cmp(t4, t2, 4U);
    if (t7 == 1)
        goto LAB4;

LAB16:    t8 = (t0 + 5654);
    t10 = xsi_mem_cmp(t8, t2, 4U);
    if (t10 == 1)
        goto LAB5;

LAB17:    t11 = (t0 + 5658);
    t13 = xsi_mem_cmp(t11, t2, 4U);
    if (t13 == 1)
        goto LAB6;

LAB18:    t14 = (t0 + 5662);
    t16 = xsi_mem_cmp(t14, t2, 4U);
    if (t16 == 1)
        goto LAB7;

LAB19:    t17 = (t0 + 5666);
    t19 = xsi_mem_cmp(t17, t2, 4U);
    if (t19 == 1)
        goto LAB8;

LAB20:    t20 = (t0 + 5670);
    t22 = xsi_mem_cmp(t20, t2, 4U);
    if (t22 == 1)
        goto LAB9;

LAB21:    t23 = (t0 + 5674);
    t25 = xsi_mem_cmp(t23, t2, 4U);
    if (t25 == 1)
        goto LAB10;

LAB22:    t26 = (t0 + 5678);
    t28 = xsi_mem_cmp(t26, t2, 4U);
    if (t28 == 1)
        goto LAB11;

LAB23:    t29 = (t0 + 5682);
    t31 = xsi_mem_cmp(t29, t2, 4U);
    if (t31 == 1)
        goto LAB12;

LAB24:    t32 = (t0 + 5686);
    t34 = xsi_mem_cmp(t32, t2, 4U);
    if (t34 == 1)
        goto LAB13;

LAB25:
LAB14:    xsi_set_current_line(82, ng0);
    t1 = (t0 + 5692);
    t3 = (t0 + 3616);
    t4 = (t3 + 56U);
    t5 = *((char **)t4);
    t8 = (t5 + 56U);
    t9 = *((char **)t8);
    memcpy(t9, t1, 4U);
    xsi_driver_first_trans_fast_port(t3);

LAB2:    t1 = (t0 + 3472);
    *((int *)t1) = 1;

LAB1:    return;
LAB3:    xsi_set_current_line(56, ng0);
    t35 = (t0 + 1032U);
    t36 = *((char **)t35);
    t35 = (t0 + 3616);
    t37 = (t35 + 56U);
    t38 = *((char **)t37);
    t39 = (t38 + 56U);
    t40 = *((char **)t39);
    memcpy(t40, t36, 4U);
    xsi_driver_first_trans_fast_port(t35);
    goto LAB2;

LAB4:    xsi_set_current_line(58, ng0);
    t1 = (t0 + 1032U);
    t2 = *((char **)t1);
    t1 = (t0 + 5540U);
    t3 = ieee_p_1242562249_sub_1919365254_1035706684(IEEE_P_1242562249, t41, t2, t1, 1);
    t4 = (t0 + 3616);
    t5 = (t4 + 56U);
    t8 = *((char **)t5);
    t9 = (t8 + 56U);
    t11 = *((char **)t9);
    memcpy(t11, t3, 4U);
    xsi_driver_first_trans_fast_port(t4);
    goto LAB2;

LAB5:    xsi_set_current_line(60, ng0);
    t1 = (t0 + 5690);
    t3 = (t0 + 1032U);
    t4 = *((char **)t3);
    t5 = ((IEEE_P_2592010699) + 4024);
    t8 = (t43 + 0U);
    t9 = (t8 + 0U);
    *((int *)t9) = 0;
    t9 = (t8 + 4U);
    *((int *)t9) = 0;
    t9 = (t8 + 8U);
    *((int *)t9) = 1;
    t6 = (0 - 0);
    t44 = (t6 * 1);
    t44 = (t44 + 1);
    t9 = (t8 + 12U);
    *((unsigned int *)t9) = t44;
    t9 = (t0 + 5540U);
    t3 = xsi_base_array_concat(t3, t42, t5, (char)97, t1, t43, (char)97, t4, t9, (char)101);
    t11 = (t0 + 1192U);
    t12 = *((char **)t11);
    t11 = (t0 + 5556U);
    t14 = ieee_p_1242562249_sub_1547198987_1035706684(IEEE_P_1242562249, t41, t3, t42, t12, t11);
    t15 = (t0 + 3680);
    t17 = (t15 + 56U);
    t18 = *((char **)t17);
    t20 = (t18 + 56U);
    t21 = *((char **)t20);
    memcpy(t21, t14, 5U);
    xsi_driver_first_trans_fast(t15);
    xsi_set_current_line(61, ng0);
    t1 = (t0 + 1992U);
    t2 = *((char **)t1);
    t44 = (4 - 3);
    t45 = (t44 * 1U);
    t46 = (0 + t45);
    t1 = (t2 + t46);
    t3 = (t0 + 3616);
    t4 = (t3 + 56U);
    t5 = *((char **)t4);
    t8 = (t5 + 56U);
    t9 = *((char **)t8);
    memcpy(t9, t1, 4U);
    xsi_driver_first_trans_fast_port(t3);
    xsi_set_current_line(62, ng0);
    t1 = (t0 + 1992U);
    t2 = *((char **)t1);
    t6 = (4 - 4);
    t44 = (t6 * -1);
    t45 = (1U * t44);
    t46 = (0 + t45);
    t1 = (t2 + t46);
    t47 = *((unsigned char *)t1);
    t3 = (t0 + 3552);
    t4 = (t3 + 56U);
    t5 = *((char **)t4);
    t8 = (t5 + 56U);
    t9 = *((char **)t8);
    *((unsigned char *)t9) = t47;
    xsi_driver_first_trans_fast_port(t3);
    goto LAB2;

LAB6:    xsi_set_current_line(64, ng0);
    t1 = (t0 + 5691);
    t3 = (t0 + 1032U);
    t4 = *((char **)t3);
    t5 = ((IEEE_P_2592010699) + 4024);
    t8 = (t48 + 0U);
    t9 = (t8 + 0U);
    *((int *)t9) = 0;
    t9 = (t8 + 4U);
    *((int *)t9) = 0;
    t9 = (t8 + 8U);
    *((int *)t9) = 1;
    t6 = (0 - 0);
    t44 = (t6 * 1);
    t44 = (t44 + 1);
    t9 = (t8 + 12U);
    *((unsigned int *)t9) = t44;
    t9 = (t0 + 5540U);
    t3 = xsi_base_array_concat(t3, t43, t5, (char)97, t1, t48, (char)97, t4, t9, (char)101);
    t11 = (t0 + 1192U);
    t12 = *((char **)t11);
    t11 = (t0 + 5556U);
    t14 = ieee_p_1242562249_sub_1547198987_1035706684(IEEE_P_1242562249, t42, t3, t43, t12, t11);
    t15 = ieee_p_1242562249_sub_1919365254_1035706684(IEEE_P_1242562249, t41, t14, t42, 1);
    t17 = (t0 + 3680);
    t18 = (t17 + 56U);
    t20 = *((char **)t18);
    t21 = (t20 + 56U);
    t23 = *((char **)t21);
    memcpy(t23, t15, 5U);
    xsi_driver_first_trans_fast(t17);
    xsi_set_current_line(65, ng0);
    t1 = (t0 + 1992U);
    t2 = *((char **)t1);
    t44 = (4 - 3);
    t45 = (t44 * 1U);
    t46 = (0 + t45);
    t1 = (t2 + t46);
    t3 = (t0 + 3616);
    t4 = (t3 + 56U);
    t5 = *((char **)t4);
    t8 = (t5 + 56U);
    t9 = *((char **)t8);
    memcpy(t9, t1, 4U);
    xsi_driver_first_trans_fast_port(t3);
    xsi_set_current_line(66, ng0);
    t1 = (t0 + 1992U);
    t2 = *((char **)t1);
    t6 = (4 - 4);
    t44 = (t6 * -1);
    t45 = (1U * t44);
    t46 = (0 + t45);
    t1 = (t2 + t46);
    t47 = *((unsigned char *)t1);
    t3 = (t0 + 3552);
    t4 = (t3 + 56U);
    t5 = *((char **)t4);
    t8 = (t5 + 56U);
    t9 = *((char **)t8);
    *((unsigned char *)t9) = t47;
    xsi_driver_first_trans_fast_port(t3);
    goto LAB2;

LAB7:    xsi_set_current_line(68, ng0);
    t1 = (t0 + 1032U);
    t2 = *((char **)t1);
    t1 = (t0 + 5540U);
    t3 = ieee_p_1242562249_sub_1919437128_1035706684(IEEE_P_1242562249, t41, t2, t1, 1);
    t4 = (t0 + 3616);
    t5 = (t4 + 56U);
    t8 = *((char **)t5);
    t9 = (t8 + 56U);
    t11 = *((char **)t9);
    memcpy(t11, t3, 4U);
    xsi_driver_first_trans_fast_port(t4);
    goto LAB2;

LAB8:    xsi_set_current_line(70, ng0);
    t1 = (t0 + 1032U);
    t2 = *((char **)t1);
    t1 = (t0 + 3616);
    t3 = (t1 + 56U);
    t4 = *((char **)t3);
    t5 = (t4 + 56U);
    t8 = *((char **)t5);
    memcpy(t8, t2, 4U);
    xsi_driver_first_trans_fast_port(t1);
    goto LAB2;

LAB9:    xsi_set_current_line(72, ng0);
    t1 = (t0 + 1032U);
    t2 = *((char **)t1);
    t1 = (t0 + 5540U);
    t3 = (t0 + 1192U);
    t4 = *((char **)t3);
    t3 = (t0 + 5556U);
    t5 = ieee_p_2592010699_sub_795620321_503743352(IEEE_P_2592010699, t41, t2, t1, t4, t3);
    t8 = (t41 + 12U);
    t44 = *((unsigned int *)t8);
    t45 = (1U * t44);
    t47 = (4U != t45);
    if (t47 == 1)
        goto LAB27;

LAB28:    t9 = (t0 + 3616);
    t11 = (t9 + 56U);
    t12 = *((char **)t11);
    t14 = (t12 + 56U);
    t15 = *((char **)t14);
    memcpy(t15, t5, 4U);
    xsi_driver_first_trans_fast_port(t9);
    goto LAB2;

LAB10:    xsi_set_current_line(74, ng0);
    t1 = (t0 + 1032U);
    t2 = *((char **)t1);
    t1 = (t0 + 5540U);
    t3 = (t0 + 1192U);
    t4 = *((char **)t3);
    t3 = (t0 + 5556U);
    t5 = ieee_p_2592010699_sub_1735675855_503743352(IEEE_P_2592010699, t41, t2, t1, t4, t3);
    t8 = (t41 + 12U);
    t44 = *((unsigned int *)t8);
    t45 = (1U * t44);
    t47 = (4U != t45);
    if (t47 == 1)
        goto LAB29;

LAB30:    t9 = (t0 + 3616);
    t11 = (t9 + 56U);
    t12 = *((char **)t11);
    t14 = (t12 + 56U);
    t15 = *((char **)t14);
    memcpy(t15, t5, 4U);
    xsi_driver_first_trans_fast_port(t9);
    goto LAB2;

LAB11:    xsi_set_current_line(76, ng0);
    t1 = (t0 + 1032U);
    t2 = *((char **)t1);
    t1 = (t0 + 5540U);
    t3 = (t0 + 1192U);
    t4 = *((char **)t3);
    t3 = (t0 + 5556U);
    t5 = ieee_p_2592010699_sub_1697423399_503743352(IEEE_P_2592010699, t41, t2, t1, t4, t3);
    t8 = (t41 + 12U);
    t44 = *((unsigned int *)t8);
    t45 = (1U * t44);
    t47 = (4U != t45);
    if (t47 == 1)
        goto LAB31;

LAB32:    t9 = (t0 + 3616);
    t11 = (t9 + 56U);
    t12 = *((char **)t11);
    t14 = (t12 + 56U);
    t15 = *((char **)t14);
    memcpy(t15, t5, 4U);
    xsi_driver_first_trans_fast_port(t9);
    goto LAB2;

LAB12:    xsi_set_current_line(78, ng0);
    t1 = (t0 + 1032U);
    t2 = *((char **)t1);
    t1 = (t0 + 5540U);
    t3 = ieee_p_1242562249_sub_2547962040_1035706684(IEEE_P_1242562249, t41, t2, t1, 1);
    t4 = (t0 + 3616);
    t5 = (t4 + 56U);
    t8 = *((char **)t5);
    t9 = (t8 + 56U);
    t11 = *((char **)t9);
    memcpy(t11, t3, 4U);
    xsi_driver_first_trans_fast_port(t4);
    goto LAB2;

LAB13:    xsi_set_current_line(80, ng0);
    t1 = (t0 + 1032U);
    t2 = *((char **)t1);
    t1 = (t0 + 5540U);
    t3 = ieee_p_1242562249_sub_2540846514_1035706684(IEEE_P_1242562249, t41, t2, t1, 1);
    t4 = (t0 + 3616);
    t5 = (t4 + 56U);
    t8 = *((char **)t5);
    t9 = (t8 + 56U);
    t11 = *((char **)t9);
    memcpy(t11, t3, 4U);
    xsi_driver_first_trans_fast_port(t4);
    goto LAB2;

LAB26:;
LAB27:    xsi_size_not_matching(4U, t45, 0);
    goto LAB28;

LAB29:    xsi_size_not_matching(4U, t45, 0);
    goto LAB30;

LAB31:    xsi_size_not_matching(4U, t45, 0);
    goto LAB32;

}


extern void work_a_2908362313_3212880686_init()
{
	static char *pe[] = {(void *)work_a_2908362313_3212880686_p_0};
	xsi_register_didat("work_a_2908362313_3212880686", "isim/TestFourBitALU_isim_beh.exe.sim/work/a_2908362313_3212880686.didat");
	xsi_register_executes(pe);
}
